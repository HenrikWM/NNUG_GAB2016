﻿using GAB.Core.Domain;
using GAB.Core.Repositories;
using GAB.Core.Repositories.DocumentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GAB.Web.Personalregister.Controllers
{
    public class AnsatteController : Controller
    {
        // GET: /Ansatte/
        public ActionResult Index()
        {
            IEnumerable<Ansatt> ansatte = DocumentDBRepository<Ansatt>.GetAllItems();

            return View(ansatte);
        }
        
        // GET: /Ansatte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ansatte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Navn,Rolle,Avdeling")] Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Ansatt>.CreateItemAsync(ansatt);

                return RedirectToAction("Index");
            }

            return View(ansatt);
        }

        // GET: /Ansatte/Edit/5
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = DocumentDBRepository<Ansatt>.GetItem(d => d.Id == id);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // POST: /Ansatte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Navn,Rolle,Avdeling")] Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Ansatt>.UpdateItemAsync(ansatt.Id, ansatt);
                return RedirectToAction("Index");
            }
            return View(ansatt);
        }

        // GET: /Ansatte/Delete/5
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = DocumentDBRepository<Ansatt>.GetItem(d => d.Id == id);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // POST: /Ansatte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed([Bind(Include = "Id")] string id)
        {
            await DocumentDBRepository<Ansatt>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}