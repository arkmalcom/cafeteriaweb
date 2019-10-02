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
    public class tipos_usuarioController : Controller
    {
        private cafeteriaEntities db = new cafeteriaEntities();

        // GET: tipos_usuario
        public ActionResult Index()
        {
            return View(db.tipos_usuario.ToList());
        }

        // GET: tipos_usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipos_usuario tipos_usuario = db.tipos_usuario.Find(id);
            if (tipos_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipos_usuario);
        }

        // GET: tipos_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipos_usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,estado")] tipos_usuario tipos_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tipos_usuario.Add(tipos_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_usuario);
        }

        // GET: tipos_usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipos_usuario tipos_usuario = db.tipos_usuario.Find(id);
            if (tipos_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipos_usuario);
        }

        // POST: tipos_usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,estado")] tipos_usuario tipos_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_usuario);
        }

        // GET: tipos_usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipos_usuario tipos_usuario = db.tipos_usuario.Find(id);
            if (tipos_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tipos_usuario);
        }

        // POST: tipos_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipos_usuario tipos_usuario = db.tipos_usuario.Find(id);
            db.tipos_usuario.Remove(tipos_usuario);
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
