using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Product
    {
        public int ID_PRODUCT { get; set; }
        public string NAME_PRODUCT { get; set; }
        public string QUANTITY_PRODUCT { get; set; }
        public int PRICE_LOT_PRODUCT { get; set; }
        public int UNIT_PRICE_PRODUCT { get; set; }
    }
}