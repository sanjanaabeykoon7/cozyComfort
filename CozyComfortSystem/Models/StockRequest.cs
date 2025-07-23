using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Models
{
    public class StockRequest
    {
        public int RequestID { get; set; }
        public int DistributorID { get; set; }
        public string DistributorName { get; set; } 
        public int BlanketID { get; set; }
        public string BlanketName { get; set; } 
        public int Quantity { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}