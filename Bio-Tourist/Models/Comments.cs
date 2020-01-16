using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Comments
    {
        public int ID_COMMENTAIRES { get; set; }
        public string TITRE_COMMENTAIRES { get; set; }
        public int DATE_COMMENTAIRES { get; set; }
        public int NOTE_COMMENTAIRES { get; set; }
        public string DESCRIPTION_COMMENTAIRES { get; set; }
    }
}