using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoCableWeb.Data;

namespace VideoCableWeb.Controllers
{
    public class CajasDistribucionesController : Controller
    {
        private VideoCableDBEntities db = new VideoCableDBEntities();

        // GET: CajasDistribuciones
        public ActionResult Index()
        {
            return View(db.CajasDistribuciones.ToList());
        }

        // GET: CajasDistribuciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasDistribucione cajasDistribucione = db.CajasDistribuciones.Find(id);
            if (cajasDistribucione == null)
            {
                return HttpNotFound();
            }
            return View(cajasDistribucione);
        }

        // GET: CajasDistribuciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CajasDistribuciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CajaDistribucionId,Descipcion,Longitud,Latitud")] CajasDistribucione cajasDistribucione)
        {
            if (ModelState.IsValid)
            {
                cajasDistribucione.FechaUltimaModificacion = DateTime.Now;
                cajasDistribucione.UsuarioUltimaModificacion = User.Identity.GetUserId();
                db.CajasDistribuciones.Add(cajasDistribucione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cajasDistribucione);
        }

        // GET: CajasDistribuciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasDistribucione cajasDistribucione = db.CajasDistribuciones.Find(id);
            if (cajasDistribucione == null)
            {
                return HttpNotFound();
            }
            return View(cajasDistribucione);
        }

        // POST: CajasDistribuciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CajaDistribucionId,Descipcion,Longitud,Latitud,FechaUltimaModificacion,UsuarioUltimaModificacion")] CajasDistribucione cajasDistribucione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajasDistribucione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cajasDistribucione);
        }

        // GET: CajasDistribuciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajasDistribucione cajasDistribucione = db.CajasDistribuciones.Find(id);
            if (cajasDistribucione == null)
            {
                return HttpNotFound();
            }
            return View(cajasDistribucione);
        }

        // POST: CajasDistribuciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CajasDistribucione cajasDistribucione = db.CajasDistribuciones.Find(id);
            db.CajasDistribuciones.Remove(cajasDistribucione);
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
