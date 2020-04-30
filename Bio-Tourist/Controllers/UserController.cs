using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.SqlClient;
using Bio_Tourist.Models;
using static Bio_Tourist.DbPath.DbPathController;
using System.Net;
using System.Net.Mail;
using Bio_Tourist.ADO;

namespace Bio_Tourist.Controllers
{
    public class UserController : Controller
    {
        //private object elseif;


        public ActionResult Inscription() // Return la view correspondante suite à un appel
        {
            if (Session["SessionEmail"] != null)
            {
                return View("ProfileList");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Connection() // Return la view correspondante suite à un appel
        {
            if (Session["SessionEmail"] != null)
            {
                return View("ProfileList");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Contact")]
        public ActionResult Contact(Bio_Tourist.Models.User v_model)
        {

            MailMessage msg = new MailMessage("expediteur@gmail.com", "biotouristcrb@gmail.com"); //Expediteur et destinataire

            msg.Subject = v_model.SUBJECT; // Sujet
            msg.Body = v_model.COMMENT;    // commentaire

            msg.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();  //Instanciation du client
            smtp.Host = "smtp.gmail.com"; // Adresse HOST gmail SMTP
            smtp.Port = 587; // Port gmail SMTP
            smtp.EnableSsl = true; //On active le protocole SSL


                NetworkCredential nc = new NetworkCredential("biotouristcrb@gmail.com", "Biotourist!2020"); // Instantiation du netwoorkCrediential
                smtp.UseDefaultCredentials = true; //On indique au client d'utiliser les informations qu'on va lui fournir
                smtp.Credentials = nc; // Permet l'identification 
                smtp.Send(msg); // soumettre les informations
            
                ViewBag.Message = "Le mail a bien été envoyé !";
 
            return View();
        }
        } 
        public ActionResult ProfileModify() // Return la view correspondante suite à un appel
        {
            if (Session["SessionEmail"] != null)
            {
                return View();
            }
            else
            {
                return View("Connection");
            }
        }


        //public ActionResult Panier()
        //{
            
        //        Session["panier"] = "blabla";//on écrit un string dans la clef "panier"
        //        if (Session["Nombre_Pages_Visitees"] != null)
        //        {
        //            Session["Nombre_Pages_Visitees"] = (int)Session["Nombre_Pages_Visitees"] + 1;
        //        }
        //        else
        //        {
        //            Session["Nombre_Pages_Visitees"] = 1;
        //        }

        //    return View();
        //}

        [HttpPost]
        public ActionResult Verify(Models.User p, Cls_Role role)
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


            if (ConnectionDataReader.Read()) // Si le DR contient 1 ligne --> Connection + Close DbPath
           
            {
                DbConnection.Close();



                Session["SessionEmail"] = p.EMAIL_USER;
                Session["SessionUserId"] = p.ID_USER;
                Session["SessionUserRole"] = p.ID_ROLE;
                return RedirectToAction("UserProfile", "User", new { SessionUsername = p.EMAIL_USER});              
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

    
        //INSCRIPTION


        [HttpPost]
        public ActionResult Register(User p)
        // INSCRIPTION ENREGISTRE LES DONNÉES UTILISATEUR DANS LA DB
        {
            // Déclaration command/path Register 
            SqlCommand RegisterCommand = new SqlCommand();
            SqlConnection DbConnection = new SqlConnection();

            // Récup + Open --> Connection à la DB
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            if (CheckExist(p)== true) // Erreur l'email existe déjà (travaillé sur les =/= possibilités d'erreur et message) + Close DbPath
            {
                DbConnection.Close();
                return View("InscriptionERROR");
            }

            else  // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande + Execute la requète
            {

                RegisterCommand.Connection = DbConnection;
                RegisterCommand.CommandText = "INSERT INTO T_USER(CIVILITY_USER , FIRST_NAME_USER , LAST_NAME_USER , AGE_USERS , EMAIL_USER , PASSWORD_USER , NUM_USER , NUM_STREET , NAME_STREET , POSTAL_CODE , CITY_USER , COUNTRY_USER , ID_ROLE) VALUES('" + p.CIVILITY_USER + "' , '" + p.FIRST_NAME_USER + "' , '" + p.LAST_NAME_USER + "' , '" + p.AGE_USERS + "' , '" + p.EMAIL_USER + "' , '" + p.PASSWORD_USER + "' , '" + p.NUM_USER + "' , '" + p.NUM_STREET + "' , '" + p.NAME_STREET + "' , '" + p.POSTAL_CODE + "' , '" + p.CITY_USER + "' , '" + p.COUNTRY_USER + "' , '" + p.ID_ROLE + "', '" + p.ID_GENDER + " ) ";
                RegisterCommand.ExecuteNonQuery();
                DbConnection.Close();
                return View("InscriptionOK");
            }
        }

        public static List<SelectListItem> DROPDOWN_LIST() //Liste du Role
        {
            List<SelectListItem> vdropdownlist = new List<SelectListItem>();
            List<Cls_Role> v_ListRole = RecupListcClsRoles();
            
            foreach(Cls_Role v_Role in v_ListRole)
            {
                vdropdownlist.Add(new SelectListItem() { Text = v_Role.NAME_ROLE, Value = v_Role.ID_ROLE.ToString() }) ;
            }
            return vdropdownlist;
        }

        public static List<Cls_Role> RecupListcClsRoles()
        {
            List<Cls_Role> v_ListRole = new List<Cls_Role>();
            // Déclaration command/path Register 
            SqlCommand RegisterCommand = new SqlCommand();
            SqlConnection DbConnection = new SqlConnection();
             // Récup + Open --> Connection à la DB
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            RegisterCommand.Connection = DbConnection;
            RegisterCommand.CommandText = "SELECT * FROM T_ROLE";
            SqlDataReader v_Datareader = RegisterCommand.ExecuteReader();//recupere adoRole
            v_ListRole = ADO_Role.fct_RecupListeObjetRole(v_Datareader);
            return v_ListRole;
        }
        public static List<Cls_GENRE> RecupListcClsGENRE()
        {
            List<Cls_GENRE> v_ListGENRE = new List<Cls_GENRE>();
            // Déclaration command/path Register 
            SqlCommand RegisterCommand = new SqlCommand();
            SqlConnection DbConnection = new SqlConnection();
            // Récup + Open --> Connection à la DB
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();


            RegisterCommand.Connection = DbConnection;
            RegisterCommand.CommandText = "SELECT * FROM T_GENDER";
            SqlDataReader v_Datareader = RegisterCommand.ExecuteReader();//recupere adoRole
            v_ListGENRE = ADO_GENRE.fct_RecupListeObjetGENRE(v_Datareader);
            return v_ListGENRE;
        }

        public ActionResult Deconnect() 
        { 
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserProfile(User p)
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
                        ID_ROLE = Convert.ToInt32(ProfileListDataReader["ID_ROLE"])

                    };

                    PfModel.Add(ProfileDetails);
                }
                p.ProfileModel = PfModel;
                DbConnection.Close();
            }
            return View("ProfileList", p);
        }

        [HttpPost]
        public ActionResult ModifyEmail(User p)
        {           
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            SqlCommand ModifyCommand = new SqlCommand();
            ModifyCommand.Connection = DbConnection;
            ModifyCommand.CommandText = "UPDATE T_USER SET EMAIL_USER = '" + p.EMAIL_USER + "' WHERE EMAIL_USER ='" + Session["SessionEmail"] + "'";
            ModifyCommand.ExecuteNonQuery();
            Session.Clear();
            Session["SessionEmail"] = p.EMAIL_USER;

            return RedirectToAction("ProfileModify", "User");
        }

        [HttpPost]
        public ActionResult ModifyPassword(User p)
        {
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            SqlCommand ModifyCommand = new SqlCommand();
            ModifyCommand.Connection = DbConnection;
            ModifyCommand.CommandText = "UPDATE T_USER SET PASSWORD_USER = '" + p.PASSWORD_USER + "' WHERE EMAIL_USER ='" + Session["SessionEmail"] + "'";
            ModifyCommand.ExecuteNonQuery();

            return RedirectToAction("ProfileModify", "User");
        }
    }
}
