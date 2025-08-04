using CozyComfortSystem.Controllers;
using CozyComfortSystem.Data;
using CozyComfortSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;

namespace CozyComfortSystem
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CozyComfortService : WebService
    {
        // Authentication Method
        [WebMethod]
        public string Login(string username, string password)
        {
            try
            {
                // Hash the input password
                string passwordHash = ComputeSha256Hash(password);

                var command = new SqlCommand("SELECT Role FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash");
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                object result = DataAccessLayer.ExecuteScalar(command);

                if (result != null)
                {
                    return result.ToString();
                }
                return "Invalid";
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        private string ComputeSha256Hash(string rawPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Manufacturer Methods
        [WebMethod]
        public List<Blanket> Manufacturer_GetBlankets()
        {
            try
            {
                var controller = new ManufacturerController();
                var blankets = controller.GetBlankets();

                // If no blankets from manufacturer, return manual list
                if (blankets == null || blankets.Count == 0)
                {
                    var sellerController = new SellerController();
                    return sellerController.GetManualBlanketList();
                }
                return blankets;
            }
            catch (Exception)
            {
                // If any error, return manual list
                var sellerController = new SellerController();
                return sellerController.GetManualBlanketList();
            }
        }

        [WebMethod]
        public string Manufacturer_AddBlanket(Blanket blanket)
        {
            var controller = new ManufacturerController();
            return controller.AddBlanket(blanket);
        }

        [WebMethod]
        public string Manufacturer_UpdateBlanket(Blanket blanket)
        {
            var controller = new ManufacturerController();
            return controller.UpdateBlanket(blanket);
        }

        [WebMethod]
        public string Manufacturer_DeleteBlanket(int blanketId)
        {
            var controller = new ManufacturerController();
            return controller.DeleteBlanket(blanketId);
        }

        [WebMethod]
        public List<StockRequest> Manufacturer_GetStockRequests()
        {
            var controller = new ManufacturerController();
            return controller.GetStockRequests();
        }

        [WebMethod]
        public string Manufacturer_ApproveRequest(int requestId)
        {
            var controller = new ManufacturerController();
            return controller.ApproveStockRequest(requestId);
        }

        [WebMethod]
        public string Manufacturer_RejectRequest(int requestId)
        {
            var controller = new ManufacturerController();
            return controller.RejectStockRequest(requestId);
        }

        // Distributor Methods
        [WebMethod]
        public List<Stock> Distributor_GetStock(int distributorId)
        {
            var controller = new DistributorController();
            return controller.GetStock(distributorId);
        }

        [WebMethod]
        public string Distributor_AddStock(Stock stockItem)
        {
            var controller = new DistributorController();
            return controller.AddStock(stockItem);
        }

        [WebMethod]
        public string Distributor_UpdateStock(int stockId, int newQuantity)
        {
            var controller = new DistributorController();
            return controller.UpdateStock(stockId, newQuantity);
        }

        [WebMethod]
        public string Distributor_DeleteStock(int stockId)
        {
            var controller = new DistributorController();
            return controller.DeleteStock(stockId);
        }

        [WebMethod]
        public List<Order> Distributor_GetSellerOrders()
        {
            var controller = new DistributorController();
            return controller.GetSellerOrders();
        }

        [WebMethod]
        public string Distributor_RequestStock(StockRequest request)
        {
            var controller = new DistributorController();
            return controller.RequestStock(request);
        }

        [WebMethod]
        public string Distributor_FulfillOrder(int orderId, int distributorId)
        {
            var controller = new DistributorController();
            return controller.FulfillSellerOrder(orderId, distributorId);
        }

        [WebMethod]
        public string Distributor_CancelOrder(int orderId)
        {
            var controller = new DistributorController();
            return controller.CancelSellerOrder(orderId);
        }

        // Seller Methods
        [WebMethod]
        public List<Stock> Seller_GetStock(int sellerId)
        {
            var controller = new SellerController();
            return controller.GetStock(sellerId);
        }

        [WebMethod]
        public string Seller_AddStock(Stock stockItem)
        {
            var controller = new SellerController();
            return controller.AddStock(stockItem);
        }

        [WebMethod]
        public string Seller_UpdateStock(int stockId, int newQuantity)
        {
            var controller = new SellerController();
            return controller.UpdateStock(stockId, newQuantity);
        }

        [WebMethod]
        public string Seller_DeleteStock(int stockId)
        {
            var controller = new SellerController();
            return controller.DeleteStock(stockId);
        }

        [WebMethod]
        public List<Order> Seller_CheckOrders(int sellerId)
        {
            var controller = new SellerController();
            return controller.CheckOrders(sellerId);
        }

        [WebMethod]
        public string Seller_PlaceOrder(Order order)
        {
            var controller = new SellerController();
            return controller.PlaceOrder(order);
        }

        [WebMethod]
        public List<Blanket> Seller_GetAvailableBlankets()
        {
            var controller = new SellerController();
            return controller.GetAvailableBlankets();
        }

        // Admin Methods
        [WebMethod]
        public List<User> Admin_GetAllUsers()
        {
            var controller = new AdminController();
            return controller.GetAllUsers();
        }

        [WebMethod]
        public string Admin_AddUser(User user)
        {
            var controller = new AdminController();
            return controller.AddUser(user);
        }

        [WebMethod]
        public string Admin_UpdateUser(User user)
        {
            var controller = new AdminController();
            return controller.UpdateUser(user);
        }

        [WebMethod]
        public string Admin_DeleteUser(int userId)
        {
            var controller = new AdminController();
            return controller.DeleteUser(userId);
        }
    }
}