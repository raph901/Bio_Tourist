using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using Bio_Tourist.Models;
using System.Data.SqlClient;
using Bio_Tourist.Controllers;

namespace Bio_Tourist.Controllers
{
    public class ContactController : Controller
    {
        // GET: EmailSetup


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Contact(Contact v_model)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(v_model.Email); //Expéditeur

            msg.To.Add(new MailAddress("biotouristcrb@gmail.com", "BioTouristcrb")); //Destinataire
            msg.Body = v_model.Surname;
            msg.Body = v_model.Name;
            msg.Body = v_model.NumStreet;
            msg.Body = v_model.NameStreet;
            msg.Body = v_model.City;
            msg.Body = v_model.NumTel;
            msg.Body = v_model.Subject;
            msg.Body = v_model.Comment;
            msg.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient(); // Instanciation du client
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true; // Activation du protocole SSL


            bool connexion = true;

            if (connexion == true)
            {
                //On indique que l'on envoie le mail par le réseau
                NetworkCredential identify = new NetworkCredential("biotouristcrb@gmail.com", "Biotourist!2020");
                //On indique au client d'utiliser les informations qu'on va lui fournir
                smtp.Credentials = identify;
                smtp.Send(msg);
                ViewBag.Message = "Le mail a bien été envoyé";
            }
            else
            {

                ViewBag.message = "Le mail n'a pas pu être envoyé.";

            }
            return View();



        }

    }
}