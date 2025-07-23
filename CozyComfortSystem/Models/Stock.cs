using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public int BlanketID { get; set; }
        public string BlanketName { get; set; } 
        public int OwnerID { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}