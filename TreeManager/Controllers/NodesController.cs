using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeManager.Database;
using TreeManager.Models;

namespace TreeManager.Controllers
{
    public class NodesController : Controller
    {
        private readonly NodeRepository nodeRepository = new NodeRepository();

        // GET: Nodes
        public ActionResult Index()
        {
            return View(nodeRepository.FindAll());
        }

        // GET: Nodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = nodeRepository.FindById(Convert.ToInt32(id));
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: Nodes/Create
        public ActionResult Create()
        {
            ViewBag.IdParent = new SelectList(nodeRepository.FindAll(), "Id", "Value");
            return View();
        }

        // POST: Nodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,IdParent")] Node node)
        {
            if (ModelState.IsValid)
            {
                nodeRepository.Add(node);
                return RedirectToAction("Index");
            }

            ViewBag.IdParent = new SelectList(nodeRepository.FindAll(), "Id", "Value", node.IdParent);
            return View(node);
        }

        // GET: Nodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = nodeRepository.FindById(Convert.ToInt32(id));
            if (node == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdParent = new SelectList(nodeRepository.FindAll(), "Id", "Value", node.IdParent);
            return View(node);
        }

        // POST: Nodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,IdParent")] Node node)
        {
            if (ModelState.IsValid)
            {
                nodeRepository.Update(node);
                return RedirectToAction("Index");
            }
            ViewBag.IdParent = new SelectList(nodeRepository.FindAll(), "Id", "Value", node.IdParent);
            return View(node);
        }

        // GET: Nodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = nodeRepository.FindById(Convert.ToInt32(id));
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nodeRepository.DeleteById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                nodeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
