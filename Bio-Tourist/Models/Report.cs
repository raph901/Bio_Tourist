using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class Report
    {
        public int ID_RAPPORTS { get; set; }
        public int NUM_RAPPORTS { get; set; }
        public string TITRE_RAPPORTS { get; set; }
        public string DATE_RAPPORTS { get; set; }
        public string DESCRIPTION_RAPPORTS { get; set; }
    }
}