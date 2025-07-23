using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortSystem.Models
{
    public class Blanket
    {
        public int BlanketID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
    }
}