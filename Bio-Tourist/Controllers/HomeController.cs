using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Bio_Tourist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Registration ()
        {
            ViewBag.Message = "Your connect page.";

            return View();
        }
        [HttpGet]
        public ActionResult Connection()
        {
            ViewBag.Message = "Your connection page.";

            return View();
        }

        SqlConnection ConnectionPath = new SqlConnection();
        SqlCommand ConnectionCommand = new SqlCommand();
        SqlDataReader ConnectionDataReader;

        void GetConnectionPath()
        {
            ConnectionPath.ConnectionString = "data source = MSI\\SQLEXPRESS; Database=BIO_TEST; integrated security = SSPI";
        }

        [HttpPost]
        public ActionResult Verify(UserTest Acc)
        {
            GetConnectionPath();
            ConnectionPath.Open();

            ConnectionCommand.Connection = ConnectionPath;
            ConnectionCommand.CommandText = "SELECT * FROM T_User WHERE Username ='" + Acc.Username + "' AND Password='" + Acc.Password + "'";
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
    }
}