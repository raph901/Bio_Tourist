using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class UserTest
    {
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; }
        
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}