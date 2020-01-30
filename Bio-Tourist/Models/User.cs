using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;
using CompareObsolete = System.Web.Mvc.CompareAttribute;


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
            public string COUNTRY_USER { get; set; }
            public string EMAIL_USER { get; set; }
            public int NUM_USER { get; set; }
            public string PASSWORD_USER { get; set; }
            public string CONFIRMING_PASSWORD { get; set; }
            public string CIVILITY_USER { get; set; }


    }
}