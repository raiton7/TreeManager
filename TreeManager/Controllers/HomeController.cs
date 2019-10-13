using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Serwis do zarządzania strukturą drzewiastą";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}