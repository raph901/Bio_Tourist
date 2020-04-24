using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bio_Tourist.Models
{
    public class TimeAnnounces
    { 

        // Permet d'afficher le temps de présence d'une annonce dans la liste des annonces

        public static string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("il y a {0} secondes", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("il y a {0} minutes", timeSpan.Minutes) :
                    "il y a plus d'une minute";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("il y a {0} heures", timeSpan.Hours) :
                    "il y a plus d'une heure";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("il y a {0} jours", timeSpan.Days) :
                    "Hier";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("Il y a {0} mois", timeSpan.Days / 30) :
                    "il y a plus d'un mois";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("il y a {0} ans", timeSpan.Days / 365) :
                    "il y a plus d'un an";
            }

            return result;
        }
    }
}