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
    public class AdminController : Controller
    {
        // GET: Admin
        //public ActionResult ReportList()
        //{
        //    return View();
        //}
        public ActionResult ReportList(Report rep)
        {
                // Déclaration command/reader/path Connection 
            SqlCommand ConnectionCommand = new SqlCommand(); // Créé la commande SQL de connection
            SqlDataReader ReportListDataReader;

                // Récup + Open --> Connection à la DB
            SqlConnection DbConnection = new SqlConnection();
            DbConnection.ConnectionString = GetDbPath();
            DbConnection.Open();

                // Insert chemin + requète sql dans la commande puis execute le reader associé à la commande
            ConnectionCommand.Connection = DbConnection;
            ConnectionCommand.CommandText = "SELECT * FROM T_REPORT";
            ReportListDataReader = ConnectionCommand.ExecuteReader();


            List<Report> RepModel = new List<Report>();

            if (ReportListDataReader.HasRows)
            {
                while (ReportListDataReader.Read())
                {
                    var ReportDetails = new Report
                    {
                        NUM_REPORT = Convert.ToInt32(ReportListDataReader["NUM_REPORT"]),
                        TITLE_REPORT = ReportListDataReader["TITLE_REPORT"].ToString(),
                        DATE_REPORT = ReportListDataReader["DATE_REPORT"].ToString(),
                        DESCRIPTION_REPORT = ReportListDataReader["DESCRIPTION_REPORT"].ToString()
                    };

                    RepModel.Add(ReportDetails);
                }
                rep.ReportModel = RepModel;
                DbConnection.Close();
            }
            return View("ReportList", rep);
        }
    }
}