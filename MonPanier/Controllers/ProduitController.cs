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
using MonPanier.ViewModels;

namespace MonPanier.Controllers
{
    [Authorize]
    public class ProduitController : Controller
    {
        private MyContext db = new MyContext();
        private UserManager<ApplicationUser> manager;

        public ProduitController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        }



        // GET: Produit
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            var produits = db.Produits.Include(p => p.Categorie).Where(p => p.ApplicationUser.Id == currentUser.Id);
            return View(produits.ToList());
        }

        // GET: Produit/Details/5
        public ActionResult Details(int? id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = db.Produits.Find(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            var ProduitRegionsModel = new ProduitRegionsModel
            {
                Produit = new Produit()
            };

            var allRegionsList = db.Regions.ToList();
            ProduitRegionsModel.AllRegions = allRegionsList.Select(o => new SelectListItem
            {
                Text = o.Nom,
                Value = o.RegionId.ToString()
            });

            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom");
            return View(ProduitRegionsModel);
        }

        // POST: Produit/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProduitId,Nom,Description,Prix,DateValid,CategorieId,Quantite,EnLigne")] Produit produit)
        public ActionResult Create(ProduitRegionsModel produitRegionsModel)
        {
            if (produitRegionsModel == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            if (ModelState.IsValid)
            {
                //var prouitUpdate = db.Produits
                //    .Include(i => i.Regions).First(i => i.ProduitId == produitRegionsModel.Produit.ProduitId);
                var produit = produitRegionsModel.Produit;

                
                    var newRegions = db.Regions.Where(
                        m => produitRegionsModel.SelectedRegions.Contains(m.RegionId)).ToList();
                    var updatedRegions = new HashSet<int>(produitRegionsModel.SelectedRegions);
                    foreach (Region region in db.Regions)
                    {
                        if (!updatedRegions.Contains(region.RegionId))
                        {
                            produit.Regions.Remove(region);
                        }
                        else
                        {
                            produit.Regions.Add((region));
                        }
                    }
                    var currentUser = manager.FindById(User.Identity.GetUserId());
                    produit.ApplicationUser = currentUser;
                    db.Produits.Add(produit);
                    db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", produitRegionsModel.Produit.CategorieId);
            return View(produitRegionsModel);







            //if (ModelState.IsValid)
            //{
            //    var currentUser = manager.FindById(User.Identity.GetUserId());
            //    produit.ApplicationUser = currentUser;
            //    db.Produits.Add(produit);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", produit.CategorieId);
            //return View(produit);
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Produit produit = db.Produits.Find(id);

            var ProduitRegionsModel = new ProduitRegionsModel
            {
                Produit = db.Produits.Include(i => i.Regions).First(i => i.ProduitId == id)
            };

            if (ProduitRegionsModel.Produit == null)
            {
                return HttpNotFound();
            }
            var allRegionsList = db.Regions.ToList();
            ProduitRegionsModel.AllRegions = allRegionsList.Select(o => new SelectListItem
            {
                Text = o.Nom,
                Value = o.RegionId.ToString()
            });

            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", ProduitRegionsModel.Produit.CategorieId);
            return View(ProduitRegionsModel);
        }

        // POST: Produit/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProduitId,Nom,Description,Prix,DateValid,CategorieId,Quantite,EnLigne")] Produit produit)
        public ActionResult Edit(ProduitRegionsModel produitRegionsModel)
        {
            if (produitRegionsModel == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            if (ModelState.IsValid)
            {
                var prouitUpdate = db.Produits
                    .Include(i => i.Regions).First(i => i.ProduitId == produitRegionsModel.Produit.ProduitId);

                if (TryUpdateModel(prouitUpdate, "Produit", new string[] { "Nom", "Description", "Prix", "DateValid", "CategorieId", "Quantite", "EnLigne" }))
                {
                    var newRegions = db.Regions.Where(
                        m => produitRegionsModel.SelectedRegions.Contains(m.RegionId)).ToList();
                    var updatedRegions = new HashSet<int>(produitRegionsModel.SelectedRegions);
                    foreach (Region region in db.Regions)
                    {
                        if (!updatedRegions.Contains(region.RegionId))
                        {
                            prouitUpdate.Regions.Remove(region);
                        }
                        else
                        {
                            prouitUpdate.Regions.Add((region));
                        }
                    }

                    db.Entry(prouitUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", produitRegionsModel.Produit.CategorieId);
            return View(produitRegionsModel);


            //if (ModelState.IsValid)
            //{
            //    db.Entry(produit).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", produit.CategorieId);
            //return View(produit);
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Produit produit = db.Produits.Find(id);

            Produit produit = db.Produits
                .Include(j => j.Regions)
                .First(j => j.ProduitId == id);

            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Produit produit = db.Produits.Find(id);
            Produit produit = db.Produits
                .Include(j => j.Regions)
                .First(j => j.ProduitId == id);
            db.Produits.Remove(produit);
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
