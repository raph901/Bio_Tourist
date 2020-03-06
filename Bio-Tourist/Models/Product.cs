using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Product
    {
        public string PICTURE_PRODUCT { get; set; }

        public int ID_PRODUCT { get; set; }
        public string NAME { get; set; }
        public string QUANTITY { get; set; }
        public int PRICE_LOT{ get; set; }
        public int PRICE_UNITY { get; set; }
    }
}