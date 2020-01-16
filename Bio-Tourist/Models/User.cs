using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class User
    {
        public int ID_USER { get; set; }
            public string LAST_NAME_USER { get; set; }
            public string FIRST_NAME_USER { get; set; }
            public int AGE_USERS { get; set; }
            public int NUM_STREET { get; set; }
            public string NAME_STREET { get; set; }
            public int POSTAL_CODE { get; set; }
            public string CITY_USER { get; set; }
            public string CONTRY_USER { get; set; }
            public string EMAIL_USER { get; set; }
            public int NUM_USER { get; set; }
            public string PASSWORD_USER { get; set; }
            public int CONFIRMING_PASSWORD { get; set; }
            public string CIVILITY_USER { get; set; }
    }
}