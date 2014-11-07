using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    public class MagasinController : Controller
    {
        // db magasin
        private MagasinContext db = new MagasinContext();
        // GET: Region
        public ActionResult Index()
        {
            var produits = db.Regions.ToList();


            return View(produits);
        }
    }
}