using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Ad
    {
        public int ID_ANNONCES { get; set; }
        public string TITRE_ANNONCES { get; set; }
        public int NUM_ANNONCES { get; set; }
        public string ADRESSE_ANNONCES { get; set; }
        public string DATE_ANNONCES { get; set; }
        public string DESCRIPTION_ANNONCES { get; set; }

    }
}