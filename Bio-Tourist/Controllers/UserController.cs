using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Bio_Tourist.Models;
using static Bio_Tourist.DbPath.DbPathController;

namespace Bio_Tourist.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Inscription() // Return la view correspondante suite à un appel
        {
            return View();
        }         
        public ActionResult Connection() // Return la view correspondante suite à un appel
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Models.User p)
        // CONNECTION : VERIFIE QUE LE LOGIN/MDP EXISTE DANS LA DB
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


            if (ConnectionDataReader.Read()) // Si le DR contient 1 ligne --> Connection + Close DbPath
            {
                DbConnection.Close();
                Session["SessionEmail"] = p.EMAIL_USER;
                return RedirectToAction("UserProfile", "User", new { SessionUsername = p.EMAIL_USER });              
            }

            else // Sinon erreur de connection (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            {
                DbConnection.Close();
                return View("ConnectionError");
            }
        }



        [HttpPost]
        public Boolean CheckExist(Models.User p)
        // CHECK SI L'EMAIL EST DEJA DANS LA DB AVANT INSCRIPTION
        {
            // Déclaration command/path/reader Check    
            SqlCommand CheckCommand = new SqlCommand();
            SqlDataReader CheckDataReader;

            // Récup + Open --> Connection à la DB
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande + Execute le Data Reader
            CheckCommand.Connection = DbConnection;
            CheckCommand.CommandText = "SELECT * FROM T_USER WHERE EMAIL_USER ='" + p.EMAIL_USER + "'";
            CheckDataReader = CheckCommand.ExecuteReader();

            // Si le DR contient 1 ligne --> Connection + Close DbPath
            if (CheckDataReader.Read())
            {
                DbConnection.Close();
                return true;
            }
            // Sinon erreur de connection (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            else
            {
                DbConnection.Close();
                return false;
            }
        }

        [HttpPost]
        public ActionResult Register(Models.User p)
        // INSCRIPTION ENREGISTRE LES DONNÉES UTILISATEUR DANS LA DB
        {
            // Déclaration command/connexion Register 
            SqlCommand RegisterCommand = new SqlCommand();
            SqlConnection DbConnection = new SqlConnection();

            // Récup + Open --> Connection à la DB
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            if (CheckExist(p) == true) // Erreur l'email existe déjà (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            {
                DbConnection.Close();
                return View("InscriptionERROR");
            }

            else // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande + Execute la requète
            {

                RegisterCommand.Connection = DbConnection;
                RegisterCommand.CommandText = "INSERT INTO T_USER(CIVILITY_USER , FIRST_NAME_USER , LAST_NAME_USER , AGE_USERS , EMAIL_USER , PASSWORD_USER , NUM_USER , NUM_STREET , NAME_STREET , POSTAL_CODE , CITY_USER , COUNTRY_USER) VALUES('" + p.CIVILITY_USER + "' , '" + p.FIRST_NAME_USER + "' , '" + p.LAST_NAME_USER + "' , '" + p.AGE_USERS + "' , '" + p.EMAIL_USER + "' , '" + p.PASSWORD_USER + "' , '" + p.NUM_USER + "' , '" + p.NUM_STREET + "' , '" + p.NAME_STREET + "' , '" + p.POSTAL_CODE + "' , '" + p.CITY_USER + "' , '" + p.COUNTRY_USER + "' ) ";
                RegisterCommand.ExecuteNonQuery();

                DbConnection.Close();
                return View("InscriptionOK");
            }
        }

        public ActionResult UserProfile(User us)
        {
            // Déclaration command/reader/path Connection 
            SqlCommand ConnectionCommand = new SqlCommand(); // Créé la commande SQL de connection
            SqlDataReader ProfileListDataReader;

            // Récup + Open --> Connection à la DB
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande
            ConnectionCommand.Connection = DbConnection;
            ConnectionCommand.CommandText = "SELECT * FROM T_USER WHERE EMAIL_USER = '" + Session["SessionEmail"] + "'";
            ProfileListDataReader = ConnectionCommand.ExecuteReader();


            List<User> PfModel = new List<User>();

            if (ProfileListDataReader.HasRows)
            {
                while (ProfileListDataReader.Read())
                {
                    var ProfileDetails = new User
                    {
                        LAST_NAME_USER = ProfileListDataReader["LAST_NAME_USER"].ToString(),
                        FIRST_NAME_USER = ProfileListDataReader["FIRST_NAME_USER"].ToString(),
                        AGE_USERS = Convert.ToInt32(ProfileListDataReader["AGE_USERS"]),
                        NUM_STREET = Convert.ToInt32(ProfileListDataReader["NUM_STREET"]),
                        NAME_STREET = ProfileListDataReader["NAME_STREET"].ToString(),
                        POSTAL_CODE = Convert.ToInt32(ProfileListDataReader["POSTAL_CODE"]),
                        CITY_USER = ProfileListDataReader["CITY_USER"].ToString(),
                        COUNTRY_USER = ProfileListDataReader["COUNTRY_USER"].ToString(),
                        EMAIL_USER = ProfileListDataReader["EMAIL_USER"].ToString(),
                        NUM_USER = Convert.ToInt32(ProfileListDataReader["NUM_USER"]),
                        PASSWORD_USER = ProfileListDataReader["PASSWORD_USER"].ToString(),
                        CIVILITY_USER = ProfileListDataReader["CIVILITY_USER"].ToString(),
                    };

                    PfModel.Add(ProfileDetails);
                }
                us.ProfileModel = PfModel;
                DbConnection.Close();
            }
            return View("ProfileList", us);
        }

        //[HttpPost]
        //public ActionResult ModifyUser(Models.User p)
        //// CONNECTION : VERIFIE QUE LE LOGIN/MDP EXISTE DANS LA DB
        //{
        //    // Déclaration command/reader/path Connection 
        //    SqlCommand ConnectionCommand = new SqlCommand(); // Créé la commande SQL de connection
        //    SqlDataReader ConnectionDataReader;

        //    // Récup + Open --> Connection à la DB
        //    SqlConnection DbConnection = new SqlConnection();
        //    DbConnection.ConnectionString = GetDbPath();
        //    DbConnection.Open();

        //    // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande
        //    ConnectionCommand.Connection = DbConnection;
        //    ConnectionCommand.CommandText = "SELECT * FROM T_USER WHERE EMAIL_USER ='" + p.EMAIL_USER + "' AND PASSWORD_USER='" + p.PASSWORD_USER + "'";
        //    ConnectionDataReader = ConnectionCommand.ExecuteReader();


        //    if (ConnectionDataReader.Read()) // Si le DR contient 1 ligne --> Connection + Close DbPath
        //    {
        //        DbConnection.Close();
        //        Session["SessionUsername"] = p.EMAIL_USER;
        //        return RedirectToAction("ConnectionSuccessful", "User", new { SessionUsername = p.EMAIL_USER });
        //    }

        //    else // Sinon erreur de connection (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
        //    {
        //        DbConnection.Close();
        //        return View("ConnectionError");
        //    }
        //}

    }
}