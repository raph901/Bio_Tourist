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
    public class InspectorController : Controller
    {
        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterReport(Models.Report p)
        // ENREGISTRE LES DONNÉES RAPPORT DANS LA DB
        {
            // Déclaration command/path RegisterReport 
            SqlCommand RegisterReportCommand = new SqlCommand();
            SqlConnection DbConnection = new SqlConnection();

            // Récup + Open --> Connection à la DB
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

            RegisterReportCommand.Connection = DbConnection;
            RegisterReportCommand.CommandText = "INSERT INTO T_REPORT(NUM_REPORT , TITLE_REPORT , DATE_REPORT , DESCRIPTION_REPORT) VALUES('" + p.NUM_REPORT + "' , '" + p.TITLE_REPORT + "' , '" + p.DATE_REPORT + "' , '" + p.DESCRIPTION_REPORT + "' ) ";
            RegisterReportCommand.ExecuteNonQuery();

            if (RegisterReportCommand.ExecuteNonQuery() == 1)
            {
                DbConnection.Close();
                return View("ReportSendOk");
            }
            else
            {
                DbConnection.Close();
                return View("ReportSendError");
            }
              
        }
    }
}