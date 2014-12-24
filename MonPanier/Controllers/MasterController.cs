using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MonPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    public class MasterController : Controller
    {
        private MyContext db = new MyContext();
        private UserManager<ApplicationUser> manager;


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var currentUser = requestContext.HttpContext.User.Identity.GetUserId();

                try
                {
                    var panier = db.Paniers.Where(p => p.ApplicationUser.Id == currentUser).First();
                    ViewData["panierNbItem"] = panier.ContenuPaniers.Count.ToString();
                }
                catch (Exception)
                {

                    ViewData["panierNbItem"] = "Deco toi !";
                }
            }
            else
                ViewData["panierNbItem"] = "Vide";
        }
    }
}