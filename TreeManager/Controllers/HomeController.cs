using System.Web.Mvc;
using TreeManager.Database;
using jsTree3.Models;
using System.Collections.Generic;

namespace TreeManager.Controllers
{
    public class HomeController : Controller
    {
        private NodeRepository nodeRepository = new NodeRepository();

        public ActionResult Index()
        {
            List<JsTree3Node> jsTree3Node = nodeRepository.ConvertModelToJS3Tree();
            if (jsTree3Node.Count > 0)
                return View(jsTree3Node[0]);
            else
                return View(new JsTree3Node());
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