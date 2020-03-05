using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class UserSeller
    {
        public partial class T_VENTE_HISTORIQUE
        {
            public int ID_SELLER { get; set; }
            public int ID_USER { get; set; }
        }
    }
}