using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Product
    {
        public int ID_PRODUIT { get; set; }
        public string NOM_PRODUIT { get; set; }
        public string QUANTITE_PRODUIT { get; set; }
        public int PRIX_LOT_PRODUIT { get; set; }
        public int PRIX_UNITAIRE_PRODUIT { get; set; }
        public string VALEUR_NUTRITIVE_PRODUIT { get; set; }
    }
}