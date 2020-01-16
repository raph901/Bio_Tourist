using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Comment
    {
        public int ID_COMMENT { get; set; }
        public string TITLE_COMMENT { get; set; }
        public int DATE_COMMENT { get; set; }
        public int NOTE_COMMENT { get; set; }
        public string DESCRIPTION_COMMENT { get; set; }
    }
}