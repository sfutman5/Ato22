using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC1;

namespace WebAppMVC1.Controllers
{
    public class Tbl_ProfilesController : Controller
    {
        private DBPrubeasEntities db = new DBPrubeasEntities();

        // GET: Tbl_Profiles
        public ActionResult Index()
        {
            return View(db.Tbl_Profiles.ToList());
        }

        // GET: Tbl_Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profiles tbl_Profiles = db.Tbl_Profiles.Find(id);
            if (tbl_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profiles);
        }

        // GET: Tbl_Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Profiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfile,Profile")] Tbl_Profiles tbl_Profiles)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Profiles.Add(tbl_Profiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Profiles);
        }

        // GET: Tbl_Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profiles tbl_Profiles = db.Tbl_Profiles.Find(id);
            if (tbl_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profiles);
        }

        // POST: Tbl_Profiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfile,Profile")] Tbl_Profiles tbl_Profiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Profiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Profiles);
        }

        // GET: Tbl_Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profiles tbl_Profiles = db.Tbl_Profiles.Find(id);
            if (tbl_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profiles);
        }

        // POST: Tbl_Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Profiles tbl_Profiles = db.Tbl_Profiles.Find(id);
            db.Tbl_Profiles.Remove(tbl_Profiles);
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
