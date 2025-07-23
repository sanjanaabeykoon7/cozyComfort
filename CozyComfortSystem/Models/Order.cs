using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int SellerID { get; set; }
        public string SellerName { get; set; } 
        public int BlanketID { get; set; }
        public string BlanketName { get; set; } 
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}