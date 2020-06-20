using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Musica()
        {
            ViewBag.Message = "Las mejores Musicas las encontraras aqui en MAXPRIME";

            return View();
        }

        public ActionResult Video()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ingresa a tu usuario ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Te puedes Registrar";

            return View();
        }



    }
}