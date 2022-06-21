using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_Ferreteria.Models;

namespace WebApp_Ferreteria.Controllers
{
    public class HerramientaController : Controller
    {
        private ferreteriaEntities db = new ferreteriaEntities();

        // GET: Herramienta
        public ActionResult Index()
        {
            return View(db.Herramienta.ToList());
        }

        // GET: Herramienta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // GET: Herramienta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Herramienta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,precio,marca,existencias")] Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                db.Herramienta.Add(herramienta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herramienta);
        }

        // GET: Herramienta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // POST: Herramienta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,precio,marca,existencias")] Herramienta herramienta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramienta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herramienta);
        }

        // GET: Herramienta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herramienta herramienta = db.Herramienta.Find(id);
            if (herramienta == null)
            {
                return HttpNotFound();
            }
            return View(herramienta);
        }

        // POST: Herramienta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Herramienta herramienta = db.Herramienta.Find(id);
            db.Herramienta.Remove(herramienta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
