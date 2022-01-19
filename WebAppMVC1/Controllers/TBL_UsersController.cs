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
    public class TBL_UsersController : Controller
    {
        private DBPrubeasEntities db = new DBPrubeasEntities();

        // GET: TBL_Users
        public ActionResult Index()
        {
            return View(db.TBL_Users.ToList());
        }

        // GET: TBL_Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // GET: TBL_Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmployee,UserName,Password,IdProfile,Status,CreatedDate,UpdateDate,Login")] TBL_Users tBL_Users)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Users.Add(tBL_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Users);
        }

        // GET: TBL_Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // POST: TBL_Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmployee,UserName,Password,IdProfile,Status,CreatedDate,UpdateDate,Login")] TBL_Users tBL_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Users);
        }

        // GET: TBL_Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // POST: TBL_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            db.TBL_Users.Remove(tBL_Users);
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
