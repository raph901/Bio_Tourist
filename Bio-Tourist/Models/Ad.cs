using DocumentFormat.OpenXml.Drawing.Pictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.SessionState;




namespace Bio_Tourist.Models
{
    public class Ad
    {
        //Session["login"] = Login;



        public int ID_AD { get; set; }

        [Required(ErrorMessage = "Le numéro de l'annonce est obligatoire")]
        public int NUM_ { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "DATE")]
        public DateTime DATEE { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        public string TITLE { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string ADRESS { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire")]
        public int POSTALCODE { get; set; }

        [Required(ErrorMessage = "La ville est obligatoire")]
        public string CITY_AD { get; set; }

        [Required(ErrorMessage = "Le pays est obligatoire")]
        public string COUNTRY_AD { get; set; }

        

        [Required(ErrorMessage = "La description est obligatoire")]
        public string DESCRIPTION_AD { get; set; }
 
    }
}