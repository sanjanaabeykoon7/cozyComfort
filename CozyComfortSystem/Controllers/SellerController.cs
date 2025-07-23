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

        // Add a new stock item
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
                    var command = new SqlCommand("INSERT INTO Stock (BlanketID, OwnerID, Quantity) VALUES (@BlanketID, @OwnerID, @Quantity)");
                    command.Parameters.AddWithValue("@BlanketID", stockItem.BlanketID);
                    command.Parameters.AddWithValue("@OwnerID", stockItem.OwnerID);
                    command.Parameters.AddWithValue("@Quantity", stockItem.Quantity);
                    DataAccessLayer.ExecuteNonQuery(command);
                    return "Stock added successfully.";
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
                    SELECT o.OrderID, o.BlanketID, b.Name AS BlanketName, o.Quantity, o.OrderDate, o.Status
                    FROM Orders o
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
                        SellerID = sellerId
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

                var command = new SqlCommand("INSERT INTO Orders (SellerID, BlanketID, Quantity, OrderDate, Status) VALUES (@SellerID, @BlanketID, @Quantity, GETDATE(), 'Pending')");
                command.Parameters.AddWithValue("@SellerID", order.SellerID);
                command.Parameters.AddWithValue("@BlanketID", order.BlanketID);
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

                // If there is data from database, return it
                if (blanketList.Count > 0)
                {
                    return blanketList;
                }
                else
                {
                    // If no data from database, return manual list
                    Console.WriteLine("No blankets found in database, returning manual list");
                    return GetManualBlanketList();
                }
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
                new Blanket { BlanketID = 1, Name = "Cozy Wool Blanket", Description = "Soft and warm wool blanket", Material = "Wool", Price = 29.99m },
                new Blanket { BlanketID = 2, Name = "Cotton Comfort Blanket", Description = "Breathable cotton blanket", Material = "Cotton", Price = 19.99m },
                new Blanket { BlanketID = 3, Name = "Fleece Warmth Blanket", Description = "Ultra-soft fleece blanket", Material = "Fleece", Price = 15.99m },
                new Blanket { BlanketID = 4, Name = "Silk Luxury Blanket", Description = "Premium silk blanket", Material = "Silk", Price = 49.99m },
                new Blanket { BlanketID = 5, Name = "Cashmere Elite Blanket", Description = "High-end cashmere blanket", Material = "Cashmere", Price = 89.99m }
            };
        }
    }
}