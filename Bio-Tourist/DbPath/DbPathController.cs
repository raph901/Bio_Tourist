using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Bio_Tourist.DbPath
{
    public class DbPathController : Controller
    {   
        // Chemin de connection à la DB (à mettre dans un fichier a part et --> GitIgnore)
        static public string GetDbPath()
        {
            // Chemin de connection à la DB (à mettre dans un fichier a part et --> GitIgnore)
            return "data source = MSI\\SQLEXPRESS; Database = BIO_TEST; integrated security = SSPI";
        }

    }
}