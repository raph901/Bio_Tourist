using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bio_Tourist.Models;

namespace Bio_Tourist.Controllers
{
    public class SellerController : Controller
    {
        private BioTouristEntities db = new BioTouristEntities();

        // return how much time passed since date object
    public static string GetTimeSince(DateTime objDateTime)
    {
        // here we are going to subtract the passed in DateTime from the current time converted to UTC
        TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(objDateTime);
        int intDays = ts.Days;
        int intHours = ts.Hours;
        int intMinutes = ts.Minutes;
        int intSeconds = ts.Seconds;

        if (intDays > 0)
            return string.Format("{0} days", intDays);

        if (intHours > 0)
            return string.Format("{0} hours", intHours);

        if (intMinutes > 0)
            return string.Format("{0} minutes", intMinutes);

        if (intSeconds > 0)
            return string.Format("{0} seconds", intSeconds);

        // let's handle future times..just in case
        if (intDays < 0)
            return string.Format("in {0} days", Math.Abs(intDays));

        if (intHours < 0)
            return string.Format("in {0} hours", Math.Abs(intHours));

        if (intMinutes < 0)
            return string.Format("in {0} minutes", Math.Abs(intMinutes));

        if (intSeconds < 0)
            return string.Format("in {0} seconds", Math.Abs(intSeconds));

        return "a bit";
    }

        public ActionResult ListAnnounces() //Affiche la liste des annonces.
        {

            var t_AD = db.T_AD.Include(t => t.T_USER);
            return View(t_AD.ToList());
        }


        public ActionResult Details(int? id) // Permet de modifier la liste
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_AD t_AD = db.T_AD.Find(id);
            if (t_AD == null)
            {
                return HttpNotFound();
            }
            return View(t_AD);
        }


        public ActionResult Create() // Affiche le formulaire d'ajout d'annonce
        {
            ViewBag.ID_USER = new SelectList(db.T_USER, "ID_USER", "LAST_NAME_USER");
            return View();
        }



       


        [HttpPost] // Pour permettre l'envoie du form
        
        [ValidateAntiForgeryToken] // Protège le contenu et l'affichage de l'utilisateur face aux pirateurs.


        // Create  : Récupére les informations du formulaire via la requete d'insertion du formulaire vers la liste des annonces.
        public ActionResult Create([Bind(Include = "ID_AD,PICTURES_AD,TITLE_AD,NAME_AD,QUANTITY_AD,PRICE_AD,ADRESS_AD,DESCRIPTION_AD,DATE_AD, RESULT_AD, ID_USER")] T_AD t_AD)
        {


            if (ModelState.IsValid)
            {
               //t_AD.RESULT_AD = t_AD.QUANTITY_AD * t_AD.PRICE_AD;

               //for(int i = t_AD.QUANTITY_AD; i <= t_AD.PRICE_AD; i++)
               // {
               //     t_AD.RESULT_AD += i;
               //     Console.WriteLine(t_AD.RESULT_AD);
                   
               // }
                    
                t_AD.ID_USER = 27;
                t_AD.PICTURES_AD = "/Images/" + t_AD.PICTURES_AD; // toujours contenu dans /images/
                db.T_AD.Add(t_AD);        
                db.SaveChanges();
                return RedirectToAction("ListAnnounces");
            }

            ViewBag.ID_USER = new SelectList(db.T_USER, "ID_USER", "LAST_NAME_USER", t_AD.ID_USER); // Liste permettant de récupérer les champs de la table USER (clé étrangère) 
            
            return View(t_AD);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_AD t_AD = db.T_AD.Find(id);
            if (t_AD == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USER = new SelectList(db.T_USER, "ID_USER", "LAST_NAME_USER", t_AD.ID_USER);
            return View(t_AD);
        }

        // POST: T_AD/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AD,PICTURES_AD,TITLE_AD,NAME_AD,QUANTITY_AD,PRICE_AD,ADRESS_AD,DESCRIPTION_AD,DATE_AD,ID_USER")] T_AD t_AD)
        {
            if (ModelState.IsValid)
            {
                //t_AD.RESULT_AD = t_AD.QUANTITY_AD * t_AD.PRICE_AD;
                t_AD.ID_USER = 27;
                t_AD.PICTURES_AD = "/Images/" + t_AD.PICTURES_AD; // toujours contenu dans images
                db.Entry(t_AD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListAnnounces");
            }
            ViewBag.ID_USER = new SelectList(db.T_USER, "ID_USER", "LAST_NAME_USER", t_AD.ID_USER);
            return View(t_AD);
        }

        // GET: T_AD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_AD t_AD = db.T_AD.Find(id);
            if (t_AD == null)
            {
                return HttpNotFound();
            }
            return View(t_AD);
        }

        // POST: T_AD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_AD t_AD = db.T_AD.Find(id);
            db.T_AD.Remove(t_AD);
            db.SaveChanges();
            return RedirectToAction("ListAnnounces");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
