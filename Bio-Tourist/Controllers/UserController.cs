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
        public ActionResult Inscription()
        {
            return View();
        }
        public ActionResult Connection()
        {
            return View();
        }

        SqlConnection ConnectionPath = new SqlConnection();
        SqlCommand ConnectionCommand = new SqlCommand();
        SqlDataReader ConnectionDataReader;

        [HttpGet]
        void GetConnectionPath()
        {
            ConnectionPath.ConnectionString = "data source = MSI\\SQLEXPRESS; Database=BIO_TEST; integrated security = SSPI";
        }

        [HttpPost]
        public ActionResult Verify(Models.UserTest p)
        {
            GetConnectionPath();
            ConnectionPath.Open();

            ConnectionCommand.Connection = ConnectionPath;
            ConnectionCommand.CommandText = "SELECT * FROM T_User WHERE Username ='" + p.Username + "' AND Password='" + p.Password + "'";
            ConnectionDataReader = ConnectionCommand.ExecuteReader();

            if (ConnectionDataReader.Read())
            {
                ConnectionPath.Close();
                return View("ConnectionSuccessful");
            }
            else
            {
                ConnectionPath.Close();
                return View("ConnectionError");
            }
        }



        [HttpPost]
        public Boolean CheckExist(Models.UserTest p)
        {
            GetConnectionPath();
            ConnectionPath.Open();
            SqlCommand CheckCommand = new SqlCommand();
            CheckCommand.Connection = ConnectionPath;
            CheckCommand.CommandText = "SELECT * FROM T_User WHERE Username ='" + p.Username + "'";
            ConnectionDataReader = CheckCommand.ExecuteReader();
            
            if (ConnectionDataReader.Read())
            {
                ConnectionPath.Close();
                return true;
            }
            else
            {
                ConnectionPath.Close();
                return false;
            }
        }

        [HttpPost]
        public ActionResult Register(Models.UserTest p)
        {
            SqlCommand RegisterCommand = new SqlCommand();

            if (CheckExist(p) == true)
            {
                ConnectionPath.Close();
                return View("InscriptionERROR");
            }
            else
            {
                GetConnectionPath();
                ConnectionPath.Open();
                RegisterCommand.Connection = ConnectionPath;
                RegisterCommand.CommandText = "INSERT INTO T_User(Username, Password) VALUES('"+ p.Username +"', '"+ p.Password +"' ) ";          
                RegisterCommand.ExecuteNonQuery();

                ConnectionPath.Close();
                return View("InscriptionOK");
            }
        }
    }
}