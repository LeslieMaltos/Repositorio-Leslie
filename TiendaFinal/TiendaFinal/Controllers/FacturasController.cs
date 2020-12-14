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
    public class FacturasController : Controller
    {
        private TiendaDeMascotasContext db = new TiendaDeMascotasContext();

        // GET: Facturas
        public ActionResult Index(string sortOrder, string searchString, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "facturaid_desc" : "";
            ViewBag.DescSortParm = sortOrder == "Descripcion" ? "descripcion_desc" : "Descripcion";
            var Facturas = from s in db.Facturas
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
                Facturas = Facturas.Where(s => s.FacturaId.ToString().Contains(searchString)
                                       || s.Descripcion.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "facturaid_desc":
                    Facturas = Facturas.OrderByDescending(s => s.FacturaId);
                    break;
                case "Descripcion":
                    Facturas = Facturas.OrderBy(s => s.Descripcion);
                    break;
                case "descripcion_desc":
                    Facturas = Facturas.OrderByDescending(s => s.Descripcion);
                    break;
                default:
                    Facturas = Facturas.OrderBy(s => s.FacturaId);
                    break;
            }
            //return View(Clientes.ToList());
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(Facturas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaId,ItemId,ClienteId,Descripcion,Cantidad,PrecioUnitario,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaId,ItemId,ClienteId,Descripcion,Cantidad,PrecioUnitario,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
