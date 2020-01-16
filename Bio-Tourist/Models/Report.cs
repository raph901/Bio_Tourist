using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Report
    {
        public int ID_REPORT { get; set; }
        public int NUM_REPORT { get; set; }
        public string TITLE_REPORT { get; set; }
        public string DATE_REPORT { get; set; }
        public string DESCRIPTION_REPORT { get; set; }
    }
}