using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Bio_Tourist.Models;

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

        [HttpGet]
        void GetDbPath()
        {
            SqlConnection DbPath = new SqlConnection();
                    // Chemin de connection à la DB (à mettre dans un fichier a part et --> GitIgnore)
            DbPath.ConnectionString = "data source = MSI\\SQLEXPRESS; Database=BIO_TEST; integrated security = SSPI";
        }

        [HttpPost]
        public ActionResult Verify(Models.UserTest p)
        // CONNECTION : VERIFIE QUE LE LOGIN/MDP EXISTE DANS LA DB
        {
                    // Déclaration command/reader/path Connection 
            SqlConnection ConnectionDbPath = new SqlConnection();
            SqlCommand ConnectionCommand = new SqlCommand(); // Créé la commande SQL de connection
            SqlDataReader ConnectionDataReader;
            
                    // Récup + Open --> Connection à la DB
            GetDbPath();
            ConnectionDbPath.Open();

                    // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande
            ConnectionCommand.Connection = ConnectionDbPath;
            ConnectionCommand.CommandText = "SELECT * FROM T_User WHERE Username ='" + p.Username + "' AND Password='" + p.Password + "'";
            ConnectionDataReader = ConnectionCommand.ExecuteReader();

                  
            if (ConnectionDataReader.Read()) // Si le DR contient 1 ligne --> Connection + Close DbPath
            {
                ConnectionDbPath.Close();
                return View("ConnectionSuccessful");
            }

            else // Sinon erreur de connection (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            {
                ConnectionDbPath.Close();
                return View("ConnectionError");
            }
        }



        [HttpPost]
        public Boolean CheckExist(Models.UserTest p)
        // CHECK SI L'EMAIL EST DEJA DANS LA DB AVANT INSCRIPTION
        {
                    // Déclaration command/path/reader Check    
            SqlCommand CheckCommand = new SqlCommand();
            SqlDataReader CheckDataReader;
            SqlConnection CheckDbPath = new SqlConnection();

                    // Récup + Open --> Connection à la DB
            GetDbPath();
            CheckDbPath.Open();

                    // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande + Execute le Data Reader
            CheckCommand.Connection = CheckDbPath;
            CheckCommand.CommandText = "SELECT * FROM T_User WHERE Username ='" + p.Username + "'";
            CheckDataReader = CheckCommand.ExecuteReader();

                    // Si le DR contient 1 ligne --> Connection + Close DbPath
            if (CheckDataReader.Read())
            {
                CheckDbPath.Close();
                return true;
            }
                    // Sinon erreur de connection (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            else
            {
                CheckDbPath.Close();
                return false;
            }
        }

        [HttpPost]
        public ActionResult Register(Models.UserTest p)
        // INSCRIPTION ENREGISTRE LES DONNÉES UTILISATEUR DANS LA DB
        {
                    // Déclaration command/path Register 
            SqlCommand RegisterCommand = new SqlCommand();
            SqlConnection RegisterDbPath = new SqlConnection();

                    // Récup + Open --> Connection à la DB
            GetDbPath();
            RegisterDbPath.Open();

            if (CheckExist(p) == true) // Erreur l'email existe déjà (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            {
                RegisterDbPath.Close();
                return View("InscriptionERROR");
            }

            else // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande + Execute la requète
            {

                RegisterCommand.Connection = RegisterDbPath;
                RegisterCommand.CommandText = "INSERT INTO T_User(Username, Password) VALUES('"+ p.Username +"', '"+ p.Password +"' ) ";          
                RegisterCommand.ExecuteNonQuery();

                RegisterDbPath.Close();
                return View("InscriptionOK");
            }
        }
    }
}