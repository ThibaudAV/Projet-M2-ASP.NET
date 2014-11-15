using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    public class CommanderController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Magasin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Liste(int idRegion)
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.CategorieId = null;
            ViewBag.idRegion = idRegion;
            var region = db.Regions.Find(idRegion);

            return View(region);
        }


        public ActionResult Categorie(int idRegion,int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.CategorieId = id;
            ViewBag.idRegion = idRegion;
            var region = db.Regions.Find(idRegion);



            return View("Liste",region);
        }


        public ActionResult Produit(int idRegion, int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.idRegion = idRegion;
            var produit = db.Produits.Find(id);

            return View(produit);
        }

    }
}