namespace Bio_Tourist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class T_AD
    {
        public int ID_AD { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Image")]
        public string PICTURES_AD { get; set; }

        [DisplayName("Titre")]
        [Required(ErrorMessage = "Le titre est obligatoire")]
        public string TITLE_AD { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string NAME_AD { get; set; }

        public int QUANTITY_AD { get; set; } // Pour le panier
        [DisplayName("€")]
        [Required(ErrorMessage = "Le prix est obligatoire")]
        public double PRICE_AD { get; set; }

        [DisplayName("Adresse")]
        [Required(ErrorMessage = "L'Adresse est obligatoire")]
        public string ADRESS_AD { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "La description est obligatoire")]
        public string DESCRIPTION_AD { get; set; }



        [DisplayName("Durée")]
        [Required(ErrorMessage = "La date est obligatoire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh\\:mm}", ApplyFormatInEditMode = true)]

        public System.DateTime DATE_AD { get; set; }
        public int ID_USER { get; set; }

        [DisplayName("Stock")]
        [Required(ErrorMessage = "Le stock est obligatoire")]
        public int STOCK_AD { get; set; }
        public int RESULT_AD { get; set; } //Pour le panier
        public Nullable<int> ID_PRODUCT { get; set; }

        [DisplayName("Ville")]
        [Required(ErrorMessage = "La ville est obligatoire")]
        public string CITY_AD { get; set; }

        [DisplayName("Pays")]
        [Required(ErrorMessage = "Le pays est obligatoire")]
        public string COUNTRY_AD { get; set; }
    
        public virtual T_PRODUCT T_PRODUCT { get; set; }
    }
}
