using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtrab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Feito por Rennan Chagas";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "rennanchagas@hotmail.com";

            return View();
        }
    }
}