using System.Web.Mvc;
using TreeManager.Database;
using jsTree3.Models;

namespace TreeManager.Controllers
{
    public class HomeController : Controller
    {
        private NodeRepository nodeRepository = new NodeRepository();

        public ActionResult Index()
        {
            JsTree3Node jsTree3Node = nodeRepository.ConvertModelToJS3Tree()[0];
            return View(jsTree3Node);
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