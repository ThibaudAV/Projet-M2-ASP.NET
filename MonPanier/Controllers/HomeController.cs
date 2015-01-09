using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPanier.Controllers
{
    public class HomeController : MasterController
    {
        public ActionResult Index()
        {
            if (TempData["message"] != null) { 
                @ViewBag.message = TempData["message"].ToString();
                @ViewBag.type = TempData["type"].ToString();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "La description de votre application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact.";

            return View();
        }
    }
}