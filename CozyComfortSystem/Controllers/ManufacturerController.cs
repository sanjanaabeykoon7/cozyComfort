using CozyComfortSystem.Data;
using CozyComfortSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CozyComfortSystem.Controllers
{
    public class ManufacturerController
    {
        public List<Blanket> GetBlankets()
        {
            var blankets = new List<Blanket>();
            try
            {
                // Add debugging to see if method is being called
                Console.WriteLine("GetBlankets method called");

                var command = new SqlCommand("SELECT * FROM Blankets");
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                // Debug: Check if DataTable has rows
                Console.WriteLine($"DataTable returned {dt.Rows.Count} rows");

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No data found in Blankets table");
                    // You can also log this or add a breakpoint here
                }

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        var blanket = new Blanket
                        {
                            BlanketID = Convert.ToInt32(row["BlanketID"]),
                            Name = row["Name"].ToString(),
                            Description = row["Description"].ToString(),
                            Material = row["Material"].ToString(),
                            Price = Convert.ToDecimal(row["Price"])
                        };
                        blankets.Add(blanket);
                        Console.WriteLine($"Added blanket: {blanket.Name}");
                    }
                    catch (Exception rowEx)
                    {
                        Console.WriteLine($"Error processing row: {rowEx.Message}");
                        // Continue processing other rows
                    }
                }

                Console.WriteLine($"Returning {blankets.Count} blankets");
            }
            catch (Exception ex)
            {
                // Enhanced error logging
                Console.WriteLine("Error in GetBlankets: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);

                // Optional: You might want to throw the exception to see it in the UI
                throw; // Uncomment this line to see the actual error in MessageBox
            }
            return blankets;
        }

        public string AddBlanket(Blanket blanket)
        {
            try
            {
                var command = new SqlCommand("INSERT INTO Blankets (Name, Description, Material, Price) VALUES (@Name, @Description, @Material, @Price)");
                command.Parameters.AddWithValue("@Name", blanket.Name);
                command.Parameters.AddWithValue("@Description", blanket.Description);
                command.Parameters.AddWithValue("@Material", blanket.Material);
                command.Parameters.AddWithValue("@Price", blanket.Price);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Blanket added successfully.";
            }
            catch (Exception ex)
            {
                return "Error adding blanket: " + ex.Message;
            }
        }

        public string UpdateBlanket(Blanket blanket)
        {
            try
            {
                var command = new SqlCommand("UPDATE Blankets SET Name = @Name, Description = @Description, Material = @Material, Price = @Price WHERE BlanketID = @BlanketID");
                command.Parameters.AddWithValue("@Name", blanket.Name);
                command.Parameters.AddWithValue("@Description", blanket.Description);
                command.Parameters.AddWithValue("@Material", blanket.Material);
                command.Parameters.AddWithValue("@Price", blanket.Price);
                command.Parameters.AddWithValue("@BlanketID", blanket.BlanketID);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Blanket updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error updating blanket: " + ex.Message;
            }
        }

        public string DeleteBlanket(int blanketId)
        {
            try
            {
                var command = new SqlCommand("DELETE FROM Blankets WHERE BlanketID = @BlanketID");
                command.Parameters.AddWithValue("@BlanketID", blanketId);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Blanket deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error deleting blanket: " + ex.Message;
            }
        }

        public List<StockRequest> GetStockRequests()
        {
            var requests = new List<StockRequest>();
            try
            {
                string sql = @"
                    SELECT 
                        sr.RequestID, sr.DistributorID, u.Username AS DistributorName,
                        sr.BlanketID, b.Name AS BlanketName, sr.Quantity, sr.RequestDate, sr.Status
                    FROM StockRequests sr
                    JOIN Users u ON sr.DistributorID = u.UserID
                    JOIN Blankets b ON sr.BlanketID = b.BlanketID
                    WHERE u.Role = 'Distributor'";

                var command = new SqlCommand(sql);
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    requests.Add(new StockRequest
                    {
                        RequestID = Convert.ToInt32(row["RequestID"]),
                        DistributorID = Convert.ToInt32(row["DistributorID"]),
                        DistributorName = row["DistributorName"].ToString(),
                        BlanketID = Convert.ToInt32(row["BlanketID"]),
                        BlanketName = row["BlanketName"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        RequestDate = Convert.ToDateTime(row["RequestDate"]),
                        Status = row["Status"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetStockRequests: " + ex.Message);
            }
            return requests;
        }

        public string ApproveStockRequest(int requestId)
        {
            try
            {
                // First, get the request details
                var selectCommand = new SqlCommand(@"
                    SELECT DistributorID, BlanketID, BlanketName, Quantity 
                    FROM StockRequests 
                    WHERE RequestID = @RequestID AND Status = 'Pending'");
                selectCommand.Parameters.AddWithValue("@RequestID", requestId);

                var requestData = DataAccessLayer.ExecuteQuery(selectCommand);

                if (requestData.Rows.Count == 0)
                {
                    return "Error: Request not found or already processed.";
                }

                var row = requestData.Rows[0];
                int distributorId = Convert.ToInt32(row["DistributorID"]);
                int blanketId = Convert.ToInt32(row["BlanketID"]);
                string blanketName = row["BlanketName"].ToString();
                int quantity = Convert.ToInt32(row["Quantity"]);

                // Update request status
                var updateRequestCommand = new SqlCommand(@"
                    UPDATE StockRequests 
                    SET Status = 'Approved' 
                    WHERE RequestID = @RequestID");
                updateRequestCommand.Parameters.AddWithValue("@RequestID", requestId);
                DataAccessLayer.ExecuteNonQuery(updateRequestCommand);

                // Check if stock entry exists
                var checkStockCommand = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM Stock 
                    WHERE BlanketID = @BlanketID AND OwnerID = @OwnerID");
                checkStockCommand.Parameters.AddWithValue("@BlanketID", blanketId);
                checkStockCommand.Parameters.AddWithValue("@OwnerID", distributorId);

                var stockExists = Convert.ToInt32(DataAccessLayer.ExecuteScalar(checkStockCommand)) > 0;

                if (stockExists)
                {
                    // Update existing stock
                    var updateStockCommand = new SqlCommand(@"
                        UPDATE Stock 
                        SET Quantity = Quantity + @Quantity, LastUpdated = GETDATE() 
                        WHERE BlanketID = @BlanketID AND OwnerID = @OwnerID");
                    updateStockCommand.Parameters.AddWithValue("@BlanketID", blanketId);
                    updateStockCommand.Parameters.AddWithValue("@OwnerID", distributorId);
                    updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                    DataAccessLayer.ExecuteNonQuery(updateStockCommand);
                }
                else
                {
                    // Insert new stock entry
                    var insertStockCommand = new SqlCommand(@"
                        INSERT INTO Stock (BlanketID, BlanketName, OwnerID, Quantity, LastUpdated) 
                        VALUES (@BlanketID, @BlanketName, @OwnerID, @Quantity, GETDATE())");
                    insertStockCommand.Parameters.AddWithValue("@BlanketID", blanketId);
                    insertStockCommand.Parameters.AddWithValue("@BlanketName", blanketName);
                    insertStockCommand.Parameters.AddWithValue("@OwnerID", distributorId);
                    insertStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                    DataAccessLayer.ExecuteNonQuery(insertStockCommand);
                }

                return "Request approved and stock updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error approving request: " + ex.Message;
            }
        }

        public string RejectStockRequest(int requestId)
        {
            try
            {
                var command = new SqlCommand("UPDATE StockRequests SET Status = 'Rejected' WHERE RequestID = @RequestID");
                command.Parameters.AddWithValue("@RequestID", requestId);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Request has been rejected.";
            }
            catch (Exception ex)
            {
                return "Error rejecting request: " + ex.Message;
            }
        }
    }
}