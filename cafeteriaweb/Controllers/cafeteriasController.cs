using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cafeteriaweb.Models;

namespace cafeteriaweb.Controllers
{
    public class cafeteriasController : Controller
    {
        private cafeteriaEntities db = new cafeteriaEntities();

        // GET: cafeterias
        public ActionResult Index()
        {
            var cafeterias = db.cafeterias.Include(c => c.campus);
            return View(cafeterias.ToList());
        }

        // GET: cafeterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeterias cafeterias = db.cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            return View(cafeterias);
        }

        // GET: cafeterias/Create
        public ActionResult Create()
        {
            ViewBag.id_campus = new SelectList(db.campus, "id", "descripcion");
            return View();
        }

        // POST: cafeterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,id_campus,encargado,estado")] cafeterias cafeterias)
        {
            if (ModelState.IsValid)
            {
                db.cafeterias.Add(cafeterias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_campus = new SelectList(db.campus, "id", "descripcion", cafeterias.id_campus);
            return View(cafeterias);
        }

        // GET: cafeterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeterias cafeterias = db.cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_campus = new SelectList(db.campus, "id", "descripcion", cafeterias.id_campus);
            return View(cafeterias);
        }

        // POST: cafeterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,id_campus,encargado,estado")] cafeterias cafeterias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafeterias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_campus = new SelectList(db.campus, "id", "descripcion", cafeterias.id_campus);
            return View(cafeterias);
        }

        // GET: cafeterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cafeterias cafeterias = db.cafeterias.Find(id);
            if (cafeterias == null)
            {
                return HttpNotFound();
            }
            return View(cafeterias);
        }

        // POST: cafeterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cafeterias cafeterias = db.cafeterias.Find(id);
            db.cafeterias.Remove(cafeterias);
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
