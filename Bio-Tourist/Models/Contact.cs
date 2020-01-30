using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Contact
    {
        [StringLength(100)]
        [Required]
        public string Surname { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string NumStreet { get; set; }

        [StringLength(100)]
        [Required]
        public string NameStreet { get; set; }

        [StringLength(100)]
        [Required]
        public string City { get; set; }

        [StringLength(100)]
        [Required]
        public string NumTel { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(100)]
        [Required]
    
        public string Subject { get; set; }

        [StringLength(100)]
        [Required]
        public string Comment { get; set; }

    }
}