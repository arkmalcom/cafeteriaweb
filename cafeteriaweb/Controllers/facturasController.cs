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
    public class facturasController : Controller
    {
        private cafeteriaEntities db = new cafeteriaEntities();

        // GET: facturas
        public ActionResult Index()
        {
            var facturas = db.facturas.Include(f => f.articulos).Include(f => f.empleados).Include(f => f.usuarios);
            return View(facturas.ToList());
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.id_articulo = new SelectList(db.articulos, "id", "descripcion");
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "nombre");
            ViewBag.id_usuario = new SelectList(db.usuarios, "id", "nombre");
            return View();
        }

        // POST: facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_empleado,id_articulo,id_usuario,fecha_venta,monto_articulo,cantidad,comentario,estado")] facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.facturas.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_articulo = new SelectList(db.articulos, "id", "descripcion", facturas.id_articulo);
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "nombre", facturas.id_empleado);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id", "nombre", facturas.id_usuario);
            return View(facturas);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_articulo = new SelectList(db.articulos, "id", "descripcion", facturas.id_articulo);
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "nombre", facturas.id_empleado);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id", "nombre", facturas.id_usuario);
            return View(facturas);
        }

        // POST: facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_empleado,id_articulo,id_usuario,fecha_venta,monto_articulo,cantidad,comentario,estado")] facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_articulo = new SelectList(db.articulos, "id", "descripcion", facturas.id_articulo);
            ViewBag.id_empleado = new SelectList(db.empleados, "id", "nombre", facturas.id_empleado);
            ViewBag.id_usuario = new SelectList(db.usuarios, "id", "nombre", facturas.id_usuario);
            return View(facturas);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facturas facturas = db.facturas.Find(id);
            db.facturas.Remove(facturas);
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
