using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{

    public class MagasinController : MasterController
    {

        private MyContext db = new MyContext();
        private UserManager<ApplicationUser> manager;

        public MagasinController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        }

        [Authorize]
        // GET: Magasin
        public ActionResult My()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());

           ViewBag.isMyMagasin = true;
           
            return View("Index",currentUser);
        }
        [Authorize]
        // GET: Magasin
        public ActionResult Edit()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());


            return View(currentUser);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "NomMagasin,DescriptionMagasin")] ApplicationUser applicationUser)
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                currentUser.NomMagasin = applicationUser.NomMagasin;
                currentUser.DescriptionMagasin = applicationUser.DescriptionMagasin;
                db.SaveChanges();
                return RedirectToAction("My");
            }
            return View(applicationUser);
        }

        public ActionResult All()
        {

            var magasins = manager.Users.ToList();

            return View(magasins);
        }
        public ActionResult Index(string id)
        {

            var magasin = manager.FindById(id);
            if (magasin == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (id == User.Identity.GetUserId())
            {
                ViewBag.isMyMagasin = true;
            }
            else
            {
                ViewBag.isMyMagasin = false;
            }
            return View(magasin);
        }
    }
}