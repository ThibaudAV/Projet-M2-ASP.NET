using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    [Authorize]
    public class MagasinController : Controller
    {

        private MyContext db = new MyContext();
        private UserManager<ApplicationUser> manager;

        public MagasinController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

        }

        // GET: Magasin
        public ActionResult Index()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());


            return View(currentUser);
        }

        // GET: Magasin
        public ActionResult Edit()
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());


            return View(currentUser);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "NomMagasin,DescriptionMagasin")] ApplicationUser applicationUser)
        {

            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                currentUser.NomMagasin = applicationUser.NomMagasin;
                currentUser.DescriptionMagasin = applicationUser.DescriptionMagasin;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }
    }
}