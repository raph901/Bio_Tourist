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
using System.Net;
using System.Net.Mail;

namespace Bio_Tourist.Models
{
    public class User
    {
            
        public int ID_ROLE { get; set; }
        public int ID_USER { get; set; }

        public int ID_GENDER { get; set; }

        [DisplayName("Nom")]
        public string LAST_NAME_USER { get; set; }
        [DisplayName("Prenom")]
        public string FIRST_NAME_USER { get; set; }

        [DisplayName("Age")]
        public int AGE_USERS { get; set; }
        [DisplayName("Numero de la Rue")]
        public int NUM_STREET { get; set; }
        [DisplayName("Nom de la rue")]
        public string NAME_STREET { get; set; }
        [DisplayName("Code postal")]
        public int POSTAL_CODE { get; set; }
        [DisplayName("Ville")]
        public string CITY_USER { get; set; }
        [DisplayName("Pays")]
        public string COUNTRY_USER { get; set; }
        [DisplayName("Email")]
        public string EMAIL_USER { get; set; }
        [DisplayName("Numero de Télephone")]
        public int NUM_USER { get; set; }
        [DisplayName("Mot de Passe")]
        public string PASSWORD_USER { get; set; }

        [DisplayName("Confirmé le mot de passe")]
        public string CONFIRMING_PASSWORD { get; set; }
        [DisplayName("Civilité")]
        public string CIVILITY_USER { get; set; }
        
        public virtual Cls_Role Cls_Role { get; set; }


        // Pour la page contact = A ne pas toucher

        public string TO { get; set; }

        public string FROM { get; set; }

        [Required(ErrorMessage = "La description est obligatoire !")]
        public string COMMENT { get; set; }

        [Required(ErrorMessage = "Le sujet est obligatoire !")]
        public string SUBJECT { get; set; }

            
    


        [DisplayName("Rols")]
        public int ROLE_USER { get; set; }
        [DisplayName("Rolr")]
        public List<User> ProfileModel { get; set; }
    }
}
