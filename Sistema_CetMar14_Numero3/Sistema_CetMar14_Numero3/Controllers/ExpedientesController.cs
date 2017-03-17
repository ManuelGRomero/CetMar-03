using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_CetMar14_Numero3.Models;

namespace Sistema_CetMar14_Numero3.Controllers
{
    public class ExpedientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expedientes
        public ActionResult Index()
        {
            var expedientes = db.expedientes.Include(e => e.alumnos).Include(e => e.especialistas);
            return View(expedientes.ToList());
        }

        // GET: Expedientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: Expedientes/Create
        public ActionResult CrearExpediente(int id)
        {

            //ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "alumnoNombre");
            ViewBag.especialistaID = new SelectList(db.especialistas, "especialistaID", "especialistaRFC");
            /*Expediente ex = new Expediente();
            ex.alumnoID = id;*/
            ViewBag.alumnoID = id;
            return View("Create");
        }

        // POST: Expedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearExpediente([Bind(Include = "expedienteID,noExpediente,alumnoID,especialistaID")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.expedientes.Add(expediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "alumnoNombre", expediente.alumnoID);
            ViewBag.especialistaID = new SelectList(db.especialistas, "especialistaID", "especialistaRFC", expediente.especialistaID);
            return View(expediente);
        }

        // GET: Expedientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "alumnoNombre", expediente.alumnoID);
            ViewBag.especialistaID = new SelectList(db.especialistas, "especialistaID", "especialistaRFC", expediente.especialistaID);
            return View(expediente);
        }

        // POST: Expedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "expedienteID,noExpediente,alumnoID,especialistaID")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "alumnoNombre", expediente.alumnoID);
            ViewBag.especialistaID = new SelectList(db.especialistas, "especialistaID", "especialistaRFC", expediente.especialistaID);
            return View(expediente);
        }

        // GET: Expedientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: Expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expediente expediente = db.expedientes.Find(id);
            db.expedientes.Remove(expediente);
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
