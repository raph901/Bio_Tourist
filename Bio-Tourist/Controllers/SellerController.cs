using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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

        [HttpPost]

        [ValidateAntiForgeryToken] // Protège le contenu et l'affichage de l'utilisateur face aux pirateurs.


        // Create  : Récupére les informations du formulaire via la requete d'insertion du formulaire vers la liste des annonces.
        public ActionResult Create([Bind(Include = "ID_AD,PICTURES_AD,TITLE_AD,NAME_AD,QUANTITY_AD,PRICE_AD,ADRESS_AD,DESCRIPTION_AD,DATE_AD,ID_USER")] T_AD t_AD)
        {
            if (ModelState.IsValid)
            {
                t_AD.ID_USER = 17;
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
