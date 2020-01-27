using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bio_Tourist.Models
{
    public class User
    {

            public int ID_USER { get; set; }

            [Required(ErrorMessage = "Veuillez entre un mot de passe")]
            public string LAST_NAME_USER { get; set; }
            public string FIRST_NAME_USER { get; set; }
            public int AGE_USERS { get; set; }
            public int NUM_STREET { get; set; }
            public string NAME_STREET { get; set; }
            public int POSTAL_CODE { get; set; }
            public string CITY_USER { get; set; }
            public string COUNTRY_USER { get; set; }

            [Remote(action: "EMAIL_USER", controller: "User")]
            public string EMAIL_USER { get; set; }
            public int NUM_USER { get; set; }

            [Required(ErrorMessage = "Veuillez entre un mot de passe")]
            [DataType(DataType.Password)]
            public string PASSWORD_USER { get; set; }

            [Required(ErrorMessage = "Confirmation du password requie")]
            [DataType(DataType.Password)]
            [System.ComponentModel.DataAnnotations.Compare("PASSWORD_USER")]
            public string CONFIRMING_PASSWORD { get; set; }
            public string CIVILITY_USER { get; set; }

    }
}