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
using VideoCableWeb.Models;

namespace VideoCableWeb.Controllers
{
    public class ClientesController : Controller
    {
        private VideoCableDBEntities db = new VideoCableDBEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Persona);


            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            var ultimoCliente = db.Clientes.ToList().OrderByDescending(x => x.NumeroPrecinto).FirstOrDefault();


            var model = new ClienteViewModel();

            if (ultimoCliente == null)
            {
                model.NumeroPrecinto = "1";
            }
            else
            {
                model.NumeroPrecinto = (Convert.ToInt64(ultimoCliente.NumeroPrecinto) + 1).ToString();
            }

            return View(model);
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var nuevaPersona = new Persona()
                {
                    RazonSocial = cliente.RazonSocial,
                    Cuit = cliente.Cuit,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Email = cliente.Email,
                    FechaUltimaModificacion = DateTime.Now,
                    UsuarioUltimaModificacion = User.Identity.GetUserId()
                };

                try
                {
                    db.Personas.Add(nuevaPersona);
                    db.SaveChanges();

                    var nuevoCliente = new Cliente()
                    {
                        PersonaId = nuevaPersona.PersonaId,
                        Direccion = nuevaPersona.Direccion,
                        NumeroPrecinto = cliente.NumeroPrecinto,
                        FechaUltimaModificacion = DateTime.Now,
                        UsuarioUltimaModificacion = User.Identity.GetUserId()
                    };

                    db.Clientes.Add(nuevoCliente);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            var model = new ClienteViewModel
            {
                ClienteId = cliente.ClienteId,
                PersonaId = cliente.PersonaId,
                Direccion = cliente.Direccion,
                NumeroPrecinto = cliente.NumeroPrecinto,
                RazonSocial = cliente.Persona.RazonSocial,
                Cuit = cliente.Persona.Cuit,
                Telefono = cliente.Persona.Telefono,
                Email = cliente.Persona.Email
            };

            return View(model);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var persona = db.Personas.FirstOrDefault(x => x.PersonaId == cliente.PersonaId);

                var clienteEntidad = db.Clientes.FirstOrDefault(x => x.ClienteId == cliente.ClienteId);

                if (clienteEntidad == null)
                {
                    return HttpNotFound();
                }

                if (persona == null)
                {
                    return HttpNotFound();
                }

                try
                {

                    persona.RazonSocial = cliente.RazonSocial;
                    persona.Cuit = persona.Cuit;
                    persona.Direccion = cliente.Direccion;
                    persona.Telefono = cliente.Telefono;
                    persona.Email = cliente.Email;
                    persona.FechaUltimaModificacion = DateTime.Now;
                    persona.UsuarioUltimaModificacion = User.Identity.GetUserId();

                    db.Entry(persona).State = EntityState.Modified;
                    db.SaveChanges();



                    clienteEntidad.Direccion = cliente.Direccion;
                    clienteEntidad.NumeroPrecinto = cliente.NumeroPrecinto;

                    clienteEntidad.FechaUltimaModificacion = DateTime.Now;
                    clienteEntidad.UsuarioUltimaModificacion = User.Identity.GetUserId();

                    db.Entry(clienteEntidad).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
