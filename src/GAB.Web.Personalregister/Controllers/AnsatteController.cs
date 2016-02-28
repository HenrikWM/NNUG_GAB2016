using GAB.Core.Domain;
using GAB.Core.Repositories;
using GAB.Core.Repositories.InMemory;
using GAB.Web.Personalregister.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GAB.Web.Personalregister.Controllers
{
    public class AnsatteController : Controller
    {
        private IRepository<Ansatt> db;

        public AnsatteController()
        {
            db = new InMemoryAnsattRepository();
        }

        // GET: /Ansatte/
        public ActionResult Index()
        {
            return View(db.GetAll());
        }
        
        // GET: /Ansatte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ansatte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                db.Add(ansatt);
                return RedirectToAction("Index");
            }

            return View(ansatt);
        }

        // GET: /Ansatte/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ansatt ansatt = db.Find(id.Value);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // POST: /Ansatte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                db.Update(ansatt);
                return RedirectToAction("Index");
            }
            return View(ansatt);
        }

        // GET: /Ansatte/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = db.Find(id.Value);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // POST: /Ansatte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ansatt ansatt = db.Find(id);
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}