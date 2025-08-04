using CozyComfortSystem.Data;
using CozyComfortSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Controllers
{
    public class DistributorController
    {
        // Get own stock items
        public List<Stock> GetStock(int distributorId)
        {
            var stockList = new List<Stock>();
            try
            {
                var command = new SqlCommand(@"
                    SELECT s.StockID, s.BlanketID, b.Name AS BlanketName, s.Quantity, s.LastUpdated
                    FROM Stock s
                    JOIN Blankets b ON s.BlanketID = b.BlanketID
                    WHERE s.OwnerID = @OwnerID");
                command.Parameters.AddWithValue("@OwnerID", distributorId);
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    stockList.Add(new Stock
                    {
                        StockID = Convert.ToInt32(row["StockID"]),
                        BlanketID = Convert.ToInt32(row["BlanketID"]),
                        BlanketName = row["BlanketName"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        LastUpdated = Convert.ToDateTime(row["LastUpdated"]),
                        OwnerID = distributorId
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetStock (Distributor): " + ex.Message);
            }
            return stockList;
        }

        // Add a new stock item (or update existing quantity for same OwnerID and BlanketID)
        public string AddStock(Stock stockItem)
        {
            try
            {
                // First check if stock already exists for this BlanketID and OwnerID
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Stock WHERE BlanketID = @BlanketID AND OwnerID = @OwnerID");
                checkCommand.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                checkCommand.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);

                int existingCount = Convert.ToInt32(DataAccessLayer.ExecuteScalar(checkCommand));

                if (existingCount > 0)
                {
                    // Update existing stock quantity
                    var updateCommand = new SqlCommand("UPDATE Stock SET Quantity = Quantity + @Quantity, LastUpdated = @LastUpdated WHERE BlanketID = @BlanketID AND OwnerID = @OwnerID");
                    updateCommand.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                    updateCommand.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                    updateCommand.Parameters.AddWithValue("@Quantity", stockItem.Quantity);
                    updateCommand.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                    DataAccessLayer.ExecuteNonQuery(updateCommand);
                    return "Stock quantity updated successfully.";
                }
                else
                {
                    // Insert new stock record
                    var insertCommand = new SqlCommand("INSERT INTO Stock (BlanketID, BlanketName, OwnerID, Quantity, LastUpdated) VALUES (@BlanketID, @BlanketName, @OwnerID, @Quantity, @LastUpdated)");
                    insertCommand.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                    insertCommand.Parameters.AddWithValue("@BlanketName", stockItem.BlanketName);
                    insertCommand.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                    insertCommand.Parameters.AddWithValue("@Quantity", stockItem.Quantity);
                    insertCommand.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                    DataAccessLayer.ExecuteNonQuery(insertCommand);
                    return "New stock added successfully.";
                }
            }
            catch (Exception ex)
            {
                return "Error adding stock: " + ex.Message;
            }
        }

        // Update an existing stock item's quantity
        public string UpdateStock(int stockId, int newQuantity)
        {
            try
            {
                var command = new SqlCommand("UPDATE Stock SET Quantity = @Quantity, LastUpdated = GETDATE() WHERE StockID = @StockID");
                command.Parameters.AddWithValue("@Quantity", newQuantity);
                command.Parameters.AddWithValue("@StockID", stockId);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Stock updated successfully.";
            }
            catch (Exception ex)
            {
                return "Error updating stock: " + ex.Message;
            }
        }

        // Delete a stock item
        public string DeleteStock(int stockId)
        {
            try
            {
                var command = new SqlCommand("DELETE FROM Stock WHERE StockID = @StockID");
                command.Parameters.AddWithValue("@StockID", stockId);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Stock deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Error deleting stock: " + ex.Message;
            }
        }

        // View orders placed by sellers
        public List<Order> GetSellerOrders()
        {
            var orderList = new List<Order>();
            try
            {
                var command = new SqlCommand(@"
                    SELECT o.OrderID, o.SellerID, u.Username AS SellerName, o.BlanketID, b.Name AS BlanketName, o.Quantity, o.OrderDate, o.Status
                    FROM Orders o
                    JOIN Users u ON o.SellerID = u.UserID
                    JOIN Blankets b ON o.BlanketID = b.BlanketID
                    WHERE u.Role = 'Seller'");

                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    orderList.Add(new Order
                    {
                        OrderID = Convert.ToInt32(row["OrderID"]),
                        SellerID = Convert.ToInt32(row["SellerID"]),
                        SellerName = row["SellerName"].ToString(),
                        BlanketID = Convert.ToInt32(row["BlanketID"]),
                        BlanketName = row["BlanketName"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        OrderDate = Convert.ToDateTime(row["OrderDate"]),
                        Status = row["Status"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSellerOrders: " + ex.Message);
            }
            return orderList;
        }

        // Request new stock from manufacturer
        public string RequestStock(StockRequest request)
        {
            try
            {
                var command = new SqlCommand("INSERT INTO StockRequests (DistributorID, DistributorName, BlanketID, BlanketName, Quantity, RequestDate, Status) VALUES (@DistributorID, @DistributorName, @BlanketID, @BlanketName, @Quantity, @RequestDate, @Status)");
                command.Parameters.AddWithValue("@DistributorID", request.DistributorID);
                command.Parameters.AddWithValue("@DistributorName", request.DistributorName ?? (object)DBNull.Value); // Handle null safely
                command.Parameters.AddWithValue("@BlanketID", request.BlanketID);
                command.Parameters.AddWithValue("@BlanketName", request.BlanketName ?? (object)DBNull.Value); // Handle null safely
                command.Parameters.AddWithValue("@Quantity", request.Quantity);
                command.Parameters.AddWithValue("@RequestDate", request.RequestDate);
                command.Parameters.AddWithValue("@Status", request.Status ?? "Pending"); // Default to "Pending" if null

                DataAccessLayer.ExecuteNonQuery(command);
                return "Stock request sent successfully.";
            }
            catch (Exception ex)
            {
                return "Error sending stock request: " + ex.Message;
            }
        }

        // Fulfill seller orders
        public string FulfillSellerOrder(int orderId, int distributorId)
        {
            try
            {
                using (var connection = DataAccessLayer.CreateConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Get order details
                            var orderCmd = new SqlCommand("SELECT BlanketID, BlanketName, Quantity, SellerID FROM Orders WHERE OrderID = @OrderID", connection, transaction);
                            orderCmd.Parameters.AddWithValue("@OrderID", orderId);

                            DataTable orderDt = new DataTable();
                            using (var adapter = new SqlDataAdapter(orderCmd))
                            {
                                adapter.Fill(orderDt);
                            }

                            if (orderDt.Rows.Count == 0)
                            {
                                transaction.Rollback();
                                return "Order not found.";
                            }

                            int blanketId = Convert.ToInt32(orderDt.Rows[0]["BlanketID"]);
                            string blanketName = orderDt.Rows[0]["BlanketName"].ToString();
                            int quantityNeeded = Convert.ToInt32(orderDt.Rows[0]["Quantity"]);
                            int sellerId = Convert.ToInt32(orderDt.Rows[0]["SellerID"]);

                            // Check distributor stock
                            var stockCmd = new SqlCommand("SELECT Quantity FROM Stock WHERE OwnerID = @OwnerID AND BlanketID = @BlanketID", connection, transaction);
                            stockCmd.Parameters.AddWithValue("@OwnerID", distributorId);
                            stockCmd.Parameters.AddWithValue("@BlanketID", blanketId);
                            object stockResult = stockCmd.ExecuteScalar();

                            if (stockResult == null || Convert.ToInt32(stockResult) < quantityNeeded)
                            {
                                transaction.Rollback();
                                return "Not enough stock to fulfill this order.";
                            }

                            // Update order status
                            var updateOrderCmd = new SqlCommand("UPDATE Orders SET Status = 'Completed' WHERE OrderID = @OrderID", connection, transaction);
                            updateOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                            updateOrderCmd.ExecuteNonQuery();

                            // Decrease distributor stock
                            var decreaseStockCmd = new SqlCommand("UPDATE Stock SET Quantity = Quantity - @Quantity, LastUpdated = GETDATE() WHERE OwnerID = @DistributorID AND BlanketID = @BlanketID", connection, transaction);
                            decreaseStockCmd.Parameters.AddWithValue("@Quantity", quantityNeeded);
                            decreaseStockCmd.Parameters.AddWithValue("@DistributorID", distributorId);
                            decreaseStockCmd.Parameters.AddWithValue("@BlanketID", blanketId);
                            decreaseStockCmd.ExecuteNonQuery();

                            // Check if seller already has this blanket in stock
                            var sellerStockCmd = new SqlCommand("SELECT COUNT(*) FROM Stock WHERE OwnerID = @SellerID AND BlanketID = @BlanketID", connection, transaction);
                            sellerStockCmd.Parameters.AddWithValue("@SellerID", sellerId);
                            sellerStockCmd.Parameters.AddWithValue("@BlanketID", blanketId);
                            int sellerStockExists = Convert.ToInt32(sellerStockCmd.ExecuteScalar());

                            if (sellerStockExists > 0)
                            {
                                // Increase seller's existing stock
                                var increaseSellerStockCmd = new SqlCommand("UPDATE Stock SET Quantity = Quantity + @Quantity, LastUpdated = GETDATE() WHERE OwnerID = @SellerID AND BlanketID = @BlanketID", connection, transaction);
                                increaseSellerStockCmd.Parameters.AddWithValue("@Quantity", quantityNeeded);
                                increaseSellerStockCmd.Parameters.AddWithValue("@SellerID", sellerId);
                                increaseSellerStockCmd.Parameters.AddWithValue("@BlanketID", blanketId);
                                increaseSellerStockCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // Create new stock entry for seller
                                var addSellerStockCmd = new SqlCommand("INSERT INTO Stock (BlanketID, BlanketName, OwnerID, Quantity, LastUpdated) VALUES (@BlanketID, @BlanketName, @SellerID, @Quantity, GETDATE())", connection, transaction);
                                addSellerStockCmd.Parameters.AddWithValue("@BlanketID", blanketId);
                                addSellerStockCmd.Parameters.AddWithValue("@BlanketName", blanketName);
                                addSellerStockCmd.Parameters.AddWithValue("@SellerID", sellerId);
                                addSellerStockCmd.Parameters.AddWithValue("@Quantity", quantityNeeded);
                                addSellerStockCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return "Order fulfilled successfully.";
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error fulfilling order: " + ex.Message;
            }
        }

        // Cancel a seller order
        public string CancelSellerOrder(int orderId)
        {
            try
            {
                var command = new SqlCommand("UPDATE Orders SET Status = 'Cancelled' WHERE OrderID = @OrderID");
                command.Parameters.AddWithValue("@OrderID", orderId);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Order has been cancelled.";
            }
            catch (Exception ex)
            {
                return "Error cancelling order: " + ex.Message;
            }
        }
    }
}