using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonPanier.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MonPanier.Controllers
{
    [Authorize]
    public class PanierController : MasterController
    {
        private MyContext db = new MyContext();
        private UserManager<ApplicationUser> manager;

        public PanierController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        }

        // ajouter une produit au panier en Ajax 

        public ActionResult AddToMyPanier(int produitId, int quantite)
        {
            if (ModelState.IsValid)
            {
                //on recupére le panier de l'utilisateur 
                var currentUser = manager.FindById(User.Identity.GetUserId());
                var paniers = db.Paniers.Include(p => p.ContenuPaniers).Where(p => p.ApplicationUser.Id == currentUser.Id);

                var produit = db.Produits.Find(produitId);

                var myPanier = paniers.First();

                // creation du nouveau contenu du panier 
                var contenuPanier = new ContenuPanier { Produit = produit, Quantite = quantite };

                // on ajoute le contenu du panier au panier 
                myPanier.ContenuPaniers.Add(contenuPanier);

                // sauvegarde dans la bdd
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        // Get : la valisation du panier 
        public ActionResult ValiderPanier()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var paniers = db.Paniers.Include(p => p.ContenuPaniers).Where(p => p.ApplicationUser.Id == currentUser.Id);

            return View(paniers.First());
        }
        // POST : Si l'utilisateur valide la commande . on supprime les elements de sont panier 
        [HttpPost]
        public ActionResult ValiderCommande()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var paniers = db.Paniers.Include(p => p.ContenuPaniers).Where(p => p.ApplicationUser.Id == currentUser.Id);
            
            TempData["message"] = "Votre commande a bien été prise en compte";
            TempData["type"] = "success";
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        // GET: Le Panier de l'utilisateur
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var paniers = db.Paniers.Include(p => p.ContenuPaniers).Where(p => p.ApplicationUser.Id == currentUser.Id);

            return View(paniers.First());
        }

        // GET: Panier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panier/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PanierId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Paniers.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(panier);
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: Panier/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PanierId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(panier);
        }

        // GET: Panier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenuPanier contenuPanier = db.ContenuPaniers.Find(id);
            if (contenuPanier == null)
            {
                return HttpNotFound();
            }
            return View(contenuPanier);
        }

        // POST: Panier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContenuPanier contenuPanier = db.ContenuPaniers.Find(id);
            db.ContenuPaniers.Remove(contenuPanier);
            db.SaveChanges();
            return RedirectToAction("Index");
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
