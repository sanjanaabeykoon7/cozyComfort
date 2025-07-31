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
    public class SellerController
    {
        // Get own stock items
        public List<Stock> GetStock(int sellerId)
        {
            var stockList = new List<Stock>();
            try
            {
                var command = new SqlCommand(@"
                    SELECT s.StockID, s.BlanketID, b.Name AS BlanketName, s.Quantity, s.LastUpdated
                    FROM Stock s
                    JOIN Blankets b ON s.BlanketID = b.BlanketID
                    WHERE s.OwnerID = @OwnerID");
                command.Parameters.AddWithValue("@OwnerID", sellerId);
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
                        OwnerID = sellerId
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetStock (Seller): " + ex.Message);
            }
            return stockList;
        }

        // Add a new stock item (or update existing quantity for same OwnerID and BlanketID)
        public string AddStock(Stock stockItem)
        {
            try
            {
                // Check if stock already exists for this seller and blanket
                var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Stock WHERE OwnerID = @OwnerID AND BlanketID = @BlanketID");
                checkCommand.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                checkCommand.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);

                object result = DataAccessLayer.ExecuteScalar(checkCommand);
                int count = Convert.ToInt32(result);

                if (count > 0)
                {
                    // Update existing stock
                    var updateCommand = new SqlCommand("UPDATE Stock SET Quantity = Quantity + @Quantity, LastUpdated = GETDATE() WHERE OwnerID = @OwnerID AND BlanketID = @BlanketID");
                    updateCommand.Parameters.AddWithValue("@Quantity", stockItem.Quantity);
                    updateCommand.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                    updateCommand.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                    DataAccessLayer.ExecuteNonQuery(updateCommand);
                    return "Stock quantity updated successfully.";
                }
                else
                {
                    // Add new stock
                    var command = new SqlCommand("INSERT INTO Stock (BlanketID, BlanketName, OwnerID, Quantity, LastUpdated) VALUES (@BlanketID, @BlanketName, @OwnerID, @Quantity, @LastUpdated)");
                    command.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                    command.Parameters.AddWithValue("@BlanketName", stockItem.BlanketName);
                    command.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                    command.Parameters.AddWithValue("@Quantity", stockItem.Quantity);
                    command.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                    DataAccessLayer.ExecuteNonQuery(command);
                    return "New Stock added successfully.";
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
                if (newQuantity < 0)
                {
                    return "Quantity cannot be negative.";
                }

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

        // Check the status of own orders
        public List<Order> CheckOrders(int sellerId)
        {
            var orderList = new List<Order>();
            try
            {
                var command = new SqlCommand(@"
                    SELECT o.OrderID, o.SellerName, o.BlanketID, b.Name AS BlanketName, o.Quantity, o.OrderDate, o.Status
                    FROM Orders o
                    JOIN Users u ON o.SellerName = u.UserName
                    JOIN Blankets b ON o.BlanketID = b.BlanketID
                    WHERE o.SellerID = @SellerID
                    ORDER BY o.OrderDate DESC");
                command.Parameters.AddWithValue("@SellerID", sellerId);
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    orderList.Add(new Order
                    {
                        OrderID = Convert.ToInt32(row["OrderID"]),
                        BlanketID = Convert.ToInt32(row["BlanketID"]),
                        BlanketName = row["BlanketName"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        OrderDate = Convert.ToDateTime(row["OrderDate"]),
                        Status = row["Status"].ToString(),
                        SellerID = sellerId,
                        SellerName = row["SellerName"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckOrders: " + ex.Message);
            }
            return orderList;
        }

        // Place a new order to a distributor
        public string PlaceOrder(Order order)
        {
            try
            {
                if (order.Quantity <= 0)
                {
                    return "Order quantity must be greater than zero.";
                }

                var command = new SqlCommand("INSERT INTO Orders (SellerID, SellerName, BlanketID, BlanketName, Quantity, OrderDate, Status) VALUES (@SellerID, @SellerName, @BlanketID, @BlanketName, @Quantity, GETDATE(), 'Pending')");
                command.Parameters.AddWithValue("@SellerID", order.SellerID);
                command.Parameters.AddWithValue("@SellerName", order.SellerName);
                command.Parameters.AddWithValue("@BlanketID", order.BlanketID);
                command.Parameters.AddWithValue("@BlanketName", order.BlanketName);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                DataAccessLayer.ExecuteNonQuery(command);
                return "Order placed successfully.";
            }
            catch (Exception ex)
            {
                return "Error placing order: " + ex.Message;
            }
        }

        // Get available blankets with manual fallback
        public List<Blanket> GetAvailableBlankets()
        {
            try
            {
                // Try to get from database first
                var blanketList = new List<Blanket>();
                var command = new SqlCommand("SELECT BlanketID, Name, Description, Material, Price FROM Blankets ORDER BY Name");
                DataTable dt = DataAccessLayer.ExecuteQuery(command);

                foreach (DataRow row in dt.Rows)
                {
                    blanketList.Add(new Blanket
                    {
                        BlanketID = Convert.ToInt32(row["BlanketID"]),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString(),
                        Material = row["Material"].ToString(),
                        Price = Convert.ToDecimal(row["Price"])
                    });
                }

                // Return database data if available, otherwise manual list
                return blanketList.Count > 0 ? blanketList : GetManualBlanketList();
            }
            catch (Exception ex)
            {
                // If any error occurs, return manual list
                Console.WriteLine("Error in GetAvailableBlankets: " + ex.Message + ", returning manual list");
                return GetManualBlanketList();
            }
        }

        // Manual blanket list fallback
        public List<Blanket> GetManualBlanketList()
        {
            return new List<Blanket>
            {
                new Blanket { BlanketID = 1, Name = "Sherpa Blanket", Description = "Double-layered sherpa fleece blanket", Material = "Sherpa Fleece", Price = 2000.00m },
                new Blanket { BlanketID = 2, Name = "Knitted Blanket", Description = "Hand-knitted chunky yarn blanket", Material = "Polyester Blend", Price = 3500.00m },
                new Blanket { BlanketID = 3, Name = "Silk Luxury Blanket", Description = "Premium silk blanket", Material = "Silk", Price = 4900.00m },
                new Blanket { BlanketID = 4, Name = "Cotton Blanket", Description = "Comfy Cotton blanket", Material = "Cotton", Price = 2500.00m },
                new Blanket { BlanketID = 5, Name = "Velvet Touch Blanket", Description = "Luxuriously soft velvet-touch blanket", Material = "Velvet", Price = 5000.00m },
                new Blanket { BlanketID = 6, Name = "Quilted Microfiber Blanket", Description = "Durable quilted blanket with microfiber fill", Material = "Microfiber", Price = 4000.00m }
            };
        }
    }
}