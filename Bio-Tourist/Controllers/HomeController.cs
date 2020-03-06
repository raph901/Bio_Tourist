    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using Bio_Tourist.Models;


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
        
        public ActionResult Registration ()
        {
            ViewBag.Message = "Your connect page.";

            return View();
        }
        public ActionResult Connection()
        {
            ViewBag.Message = "Your connect page.";

            return View();
        }

    }
}