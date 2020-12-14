using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaFinal.DAL;
using TiendaFinal.Models;

namespace TiendaFinal.Controllers
{
    public class PerroesController : Controller
    {
        private TiendaDeMascotasContext db = new TiendaDeMascotasContext();

        // GET: Perroes
        public ActionResult Index(string sortOrder, string searchString, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewBag.RazaSortParm = sortOrder == "Raza" ? "raza_desc" : "Raza";
            var Perros = from s in db.Perros
                           select s;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                Perros = Perros.Where(s => s.Nombre.Contains(searchString)
                                       || s.Raza.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    Perros = Perros.OrderByDescending(s => s.Nombre);
                    break;
                case "Raza":
                    Perros = Perros.OrderBy(s => s.Raza);
                    break;
                case "apellidopaterno_desc":
                    Perros = Perros.OrderByDescending(s => s.Raza);
                    break;
                default:
                    Perros = Perros.OrderBy(s => s.Nombre);
                    break;
            }
            //return View(Clientes.ToList());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(Perros.ToPagedList(pageNumber, pageSize));
        }

        // GET: Perroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perro perro = db.Perros.Find(id);
            if (perro == null)
            {
                return HttpNotFound();
            }
            return View(perro);
        }

        // GET: Perroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerroId,Nombre,Raza,Precio,Sexo,FechaDeNacimiento")] Perro perro)
        {
            if (ModelState.IsValid)
            {
                db.Perros.Add(perro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perro);
        }

        // GET: Perroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perro perro = db.Perros.Find(id);
            if (perro == null)
            {
                return HttpNotFound();
            }
            return View(perro);
        }

        // POST: Perroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerroId,Nombre,Raza,Precio,Sexo,FechaDeNacimiento")] Perro perro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perro);
        }

        // GET: Perroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perro perro = db.Perros.Find(id);
            if (perro == null)
            {
                return HttpNotFound();
            }
            return View(perro);
        }

        // POST: Perroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perro perro = db.Perros.Find(id);
            db.Perros.Remove(perro);
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
