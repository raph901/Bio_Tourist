using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Bio_Tourist.DbPath.DbPathController;
using Bio_Tourist.Models;

namespace Bio_Tourist.Controllers
{
    public class maptest
    {

        [HttpPost]
        public ActionResult Verify(Models.testmap p)
        // CONNECTION : VERIFIE QUE LE LOGIN/MDP EXISTE DANS LA DB //
        {
            // Déclaration command/reader/path Connection 
            SqlCommand ConnectionCommand = new SqlCommand(); // Créé la commande SQL de connection
            SqlDataReader ConnectionDataReader;

            // Récup + Open --> Connection à la DB
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande
            ConnectionCommand.Connection = DbConnection;
            ConnectionCommand.CommandText = "SELECT * FROM T_USER WHERE EMAIL_USER ='" + p.EMAIL_USER + "' AND PASSWORD_USER='" + p.PASSWORD_USER + "'";
            ConnectionDataReader = ConnectionCommand.ExecuteReader();
            return ("Inscription");
        }
    }
}