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
            ConnectionPath.ConnectionString = "data source = RAPHAËL\\SQLEXPRESS; Database=BioTourist; integrated security = SSPI";
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
        public ActionResult Register(Models.User p)
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
                RegisterCommand.CommandText =
                    "INSERT INTO T_USER(CIVILITY_USER , FIRST_NAME_USER , LAST_NAME_USER , AGE_USERS , EMAIL_USER , PASSWORD_USER , NUM_USER , NUM_STREET , NAME_STREET , POSTAL_CODE , CITY_USER , COUNTRY_USER) VALUES('" + p.CIVILITY_USER + "' , '" + p.FIRST_NAME_USER + "' , '" + p.LAST_NAME_USER + "' , '" + p.AGE_USERS + "' , '" + p.EMAIL_USER + "' , '" + p.PASSWORD_USER + "' , '" + p.NUM_USER + "' , '" + p.NUM_STREET + "' , '" + p.NAME_STREET + "' , '" + p.POSTAL_CODE + "' , '" + p.CITY_USER + "' , '" + p.COUNTRY_USER + "' ) ";
                RegisterCommand.ExecuteNonQuery();

                ConnectionPath.Close();
                return View("InscriptionOK");
            }
        }

        [HttpPost]
        public Boolean CheckExist(Models.User p)
        {
            GetConnectionPath();
            ConnectionPath.Open();
            SqlCommand CheckCommand = new SqlCommand();
            CheckCommand.Connection = ConnectionPath;
            CheckCommand.CommandText = "SELECT * FROM T_USER WHERE EMAIL_USER ='" + p.EMAIL_USER + "'";
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

    }
}