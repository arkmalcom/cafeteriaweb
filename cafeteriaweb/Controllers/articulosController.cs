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
    public class articulosController : Controller
    {
        private cafeteriaEntities db = new cafeteriaEntities();

        // GET: articulos
        public ActionResult Index()
        {
            var articulos = db.articulos.Include(a => a.marcas).Include(a => a.proveedores);
            return View(articulos.ToList());
        }

        // GET: articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulos articulos = db.articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: articulos/Create
        public ActionResult Create()
        {
            ViewBag.id_marca = new SelectList(db.marcas, "id", "descripcion");
            ViewBag.id_proveedor = new SelectList(db.proveedores, "id", "nombre_comercial");
            return View();
        }

        // POST: articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,id_marca,costo,id_proveedor,existencia,estado")] articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_marca = new SelectList(db.marcas, "id", "descripcion", articulos.id_marca);
            ViewBag.id_proveedor = new SelectList(db.proveedores, "id", "nombre_comercial", articulos.id_proveedor);
            return View(articulos);
        }

        // GET: articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulos articulos = db.articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_marca = new SelectList(db.marcas, "id", "descripcion", articulos.id_marca);
            ViewBag.id_proveedor = new SelectList(db.proveedores, "id", "nombre_comercial", articulos.id_proveedor);
            return View(articulos);
        }

        // POST: articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,id_marca,costo,id_proveedor,existencia,estado")] articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_marca = new SelectList(db.marcas, "id", "descripcion", articulos.id_marca);
            ViewBag.id_proveedor = new SelectList(db.proveedores, "id", "nombre_comercial", articulos.id_proveedor);
            return View(articulos);
        }

        // GET: articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulos articulos = db.articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            articulos articulos = db.articulos.Find(id);
            db.articulos.Remove(articulos);
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
