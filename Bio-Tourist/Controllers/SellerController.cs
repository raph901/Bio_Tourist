using System;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Bio_Tourist.Models;
using Bio_Tourist.Models.Tools;

namespace Bio_Tourist.Controllers
{
    public class SellerController : Controller
    {
        private BioTouristEntities db = new BioTouristEntities();


        //Affiche la liste des annonces
        public ActionResult ListAnnounces()
        {
            return View();
        }

        // Filtrages avec la barre de recherche intégrée dans la liste des annonces.


        [HttpGet] // Le filtrage se fait à partir de l'onglet url en get Http.
        public ViewResult ListAnnounces(string searching)
        {

            var ad = db.T_AD.Include(prod => prod.T_PRODUCT);

            if (!string.IsNullOrEmpty(searching))
            {
                ad = from Research in db.T_AD
                     where

            Research.NAME_AD.Contains(searching) ||
            Research.TITLE_AD.Contains(searching) ||
            Research.T_PRODUCT.CATEGORIE_PRODUCT.Contains(searching) ||
            Research.CITY_AD.Contains(searching) ||
            Research.COUNTRY_AD.Contains(searching)

                     select Research;
            }
            return View(ad.ToList());


        }

        // Permet d'afficher un élément, une annonce de la liste des annonces en utilisant son ID (ID_AD)
        public ActionResult Details(int? id)
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

        public ActionResult DownloadImage(DownloadPicture picture) //Permet de télécharger une image 
        {
            if (picture.postedFile != null)
            {
                string path = Server.MapPath("~/ImagesUserServer/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                picture.postedFile.SaveAs(path + Path.GetFileName(picture.postedFile.FileName));

                ViewBag.Message = "Votre image a été téléchargée avec succès. Vous pouvez maintenant charger votre image via le formulaire d'ajout";

            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // Create  : Permet d'ajouter une annonce via le formulaire avec une requête d'insertion vers la liste des annonces.
        [HttpPost] // Pour permettre l'envoie du formulaire
        [ValidateAntiForgeryToken] // Protège le contenu et l'affichage de l'utilisateur face aux contrefaçon.
        public ActionResult Create([Bind(Include = "ID_AD,PICTURES_AD,TITLE_AD,NAME_AD,STOCK_AD,PRICE_AD,ADRESS_AD,CITY_AD,COUNTRY_AD,DESCRIPTION_AD,DATE_AD, ID_USER,T_PRODUCT,CATEGORIE_PRODUCT")] T_AD p, T_AD download)
        {

            p.ID_USER = 27; //Provisoire en attente de session 

            if (ModelState.IsValid)
            {
                p.PICTURES_AD = "/ImagesUserServer/" + p.PICTURES_AD; // Image téléchargeable
              //p.PICTURES_AD = "/ImagesUser/" + p.PICTURES_AD; // Image en local
                db.T_AD.Add(p);
                db.SaveChanges();
                ViewBag.message = "L'annonce a été ajouté avec succès =)";
            }

            return View(p);

        }


        // Permet de modifier un élément de la liste des annonces en utilisant son ID. (exemple : une annonce)
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

            return View(t_AD);
        }


        // Permet de modifier une annonce avec la requête UPDATE d'EF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AD,PICTURES_AD,TITLE_AD,NAME_AD,STOCK_AD,PRICE_AD,DATE_AD,ADRESS_AD,DESCRIPTION_AD,COUNTRY_AD, CITY_AD, ID_USER, T_PRODUCT, CATEGORIE_PRODUCT")] T_AD p)
        {
            p.ID_USER = 27; //Provisoire en attente de session

            if (ModelState.IsValid)
            {
                p.PICTURES_AD = "/ImagesUserServer/" + p.PICTURES_AD; // Image téléchargeable
                //p.PICTURES_AD = "/ImagesUser/" + p.PICTURES_AD; // Image local 
                db.T_AD.Add(p);
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.message = "La modification a bien été pris en compte.";

            return View(p);
        }
        // Permet de supprimer un élément, une annonce de la liste des annonces en utilisant son ID (ID_AD)
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

        // Permet de confirmer la suppression d'une annonce moyennant de ID_AD.

        [HttpPost, ActionName("Delete")] // Reprend la méthode delete ci dessus.

        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_AD t_AD = db.T_AD.Find(id);
            db.T_AD.Remove(t_AD);
            db.SaveChanges();
            return RedirectToAction("ListAnnounces");
        }


        //Méthode permettant de libérer des ressources non utilisées pour libérer de la mémoire sur l'application.
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
