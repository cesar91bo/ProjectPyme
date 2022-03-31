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
using VideoCableWeb.Enums;

namespace VideoCableWeb.Controllers
{
    public class ClientesCajasDistribucionesServiciosController : Controller
    {
        private VideoCableDBEntities db = new VideoCableDBEntities();

        // GET: ClientesCajasDistribucionesServicios
        public ActionResult Index(int? clienteId)
        {
            Cliente cliente = new Cliente();

            List<ClientesCajasDistribucionesServicio> listado = new List<ClientesCajasDistribucionesServicio>();

            if (clienteId != null)
            {
                cliente = db.Clientes.FirstOrDefault(x => x.ClienteId == clienteId.Value);

                if (cliente == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ViewBag.Cliente = cliente.Persona.RazonSocial;
                ViewBag.ClienteId = cliente.ClienteId;

                listado = db.ClientesCajasDistribucionesServicios.Where(x => x.ClienteId == clienteId).ToList();

            }

            return View(listado);
        }

        // GET: ClientesCajasDistribucionesServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio = db.ClientesCajasDistribucionesServicios.Find(id);
            if (clientesCajasDistribucionesServicio == null)
            {
                return HttpNotFound();
            }
            return View(clientesCajasDistribucionesServicio);
        }

        // GET: ClientesCajasDistribucionesServicios/Create
        public ActionResult Create(int clienteId)
        {
            ViewBag.CajaDistribucionId = new SelectList(db.CajasDistribuciones, "CajaDistribucionId", "Descipcion");
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Persona.RazonSocial", clienteId);
            ViewBag.ServicioId = new SelectList(db.Servicios.Where(x => x.Activo.HasValue && x.Activo.Value), "ServicioId", "Descripcion");
            ViewBag.Cliente = clienteId;
            return View();
        }

        // POST: ClientesCajasDistribucionesServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteCajaDistribucionServicioId,ClienteId,CajaDistribucionId,ServicioId")] ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    clientesCajasDistribucionesServicio.FechaUltimaModificacion = DateTime.Now;
                    clientesCajasDistribucionesServicio.UsuarioUltimaModificacion = User.Identity.GetUserId();

                    db.ClientesCajasDistribucionesServicios.Add(clientesCajasDistribucionesServicio);
                    db.SaveChanges();

                    var clienteCajaDistribucionServicioEstado = new ClientesCajasDistribucionesServiciosEstado
                    {
                        ClienteCajaDistribucionServicioId = clientesCajasDistribucionesServicio.ClienteCajaDistribucionServicioId,
                        EstadoId = (int)EstadoEnum.Creado,
                        FechaUltimaModificacion = DateTime.Now,
                        UsuarioUltimaModificacion = User.Identity.GetUserId()

                    };

                    db.ClientesCajasDistribucionesServiciosEstados.Add(clienteCajaDistribucionServicioEstado);
                    db.SaveChanges();

                    var ultimoEstado = db.ClientesCajasDistribucionesServiciosEstados.OrderByDescending(x => x.FechaUltimaModificacion).FirstOrDefault();
                    if (ultimoEstado == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    clientesCajasDistribucionesServicio.UltimoEstadoId = ultimoEstado.EstadoId;


                    db.Entry(clientesCajasDistribucionesServicio).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", new { clienteId = clientesCajasDistribucionesServicio .ClienteId});
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            ViewBag.CajaDistribucionId = new SelectList(db.CajasDistribuciones, "CajaDistribucionId", "Descipcion", clientesCajasDistribucionesServicio.CajaDistribucionId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Direccion", clientesCajasDistribucionesServicio.ClienteId);
            ViewBag.ServicioId = new SelectList(db.Servicios.Where(x => x.Activo.HasValue && x.Activo.Value), "ServicioId", "Descripcion", clientesCajasDistribucionesServicio.ServicioId);
            return View(clientesCajasDistribucionesServicio);
        }

        // GET: ClientesCajasDistribucionesServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio = db.ClientesCajasDistribucionesServicios.Find(id);
            if (clientesCajasDistribucionesServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CajaDistribucionId = new SelectList(db.CajasDistribuciones, "CajaDistribucionId", "Descipcion", clientesCajasDistribucionesServicio.CajaDistribucionId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Direccion", clientesCajasDistribucionesServicio.ClienteId);
            ViewBag.UltimoEstadoId = new SelectList(db.Estados, "EstadoId", "Descripcion", clientesCajasDistribucionesServicio.UltimoEstadoId);
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Descripcion", clientesCajasDistribucionesServicio.ServicioId);
            return View(clientesCajasDistribucionesServicio);
        }

        // POST: ClientesCajasDistribucionesServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteCajaDistribucionServicioId,ClienteId,CajaDistribucionId,ServicioId,UltimoEstadoId,FechaUltimaModificacion,UsuarioUltimaModificacion")] ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientesCajasDistribucionesServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CajaDistribucionId = new SelectList(db.CajasDistribuciones, "CajaDistribucionId", "Descipcion", clientesCajasDistribucionesServicio.CajaDistribucionId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Direccion", clientesCajasDistribucionesServicio.ClienteId);
            ViewBag.UltimoEstadoId = new SelectList(db.Estados, "EstadoId", "Descripcion", clientesCajasDistribucionesServicio.UltimoEstadoId);
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Descripcion", clientesCajasDistribucionesServicio.ServicioId);
            return View(clientesCajasDistribucionesServicio);
        }

        // GET: ClientesCajasDistribucionesServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio = db.ClientesCajasDistribucionesServicios.Find(id);
            if (clientesCajasDistribucionesServicio == null)
            {
                return HttpNotFound();
            }
            return View(clientesCajasDistribucionesServicio);
        }

        // POST: ClientesCajasDistribucionesServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesCajasDistribucionesServicio clientesCajasDistribucionesServicio = db.ClientesCajasDistribucionesServicios.Find(id);
            db.ClientesCajasDistribucionesServicios.Remove(clientesCajasDistribucionesServicio);
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
