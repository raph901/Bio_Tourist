using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class User
    {
        public partial class T_USER
        {
            public int ID_USER { get; set; }
            public string NOM_USER { get; set; }
            public string PRENOM_USER { get; set; }
            public int AGE_USERS { get; set; }
            public int NUM_RUE { get; set; }
            public string NOM_RUE { get; set; }
            public int CODE_POSTAL { get; set; }
            public string VILLE_USER { get; set; }
            public string PAYS_USER { get; set; }
            public string EMAIL_USER { get; set; }
            public int NUM_USER { get; set; }
            public string PASSWORD_USER { get; set; }
            public string CIVILITE_USER { get; set; }
        }
    }
}