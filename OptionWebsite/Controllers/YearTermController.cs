using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel.Models;
using OptionWebsite.Models;

namespace OptionWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YearTermController : Controller
    {
        private const string AdministratorRole = "Admin";
        private DataContext db = new DataContext();

        // GET: /YearTerm/
        public ActionResult Index()
        {
            return View(db.YearTerms.ToList());
        }

        // GET: /YearTerm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearterm = db.YearTerms.Find(id);
            if (yearterm == null)
            {
                return HttpNotFound();
            }
            return View(yearterm);
        }

        // GET: /YearTerm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /YearTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="YearTermId,Year,Term,IsDefault")] YearTerm yearterm)
        {
            if (ModelState.IsValid)
            {
                db.YearTerms.Add(yearterm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearterm);
        }

        // GET: /YearTerm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearterm = db.YearTerms.Find(id);
            if (yearterm == null)
            {
                return HttpNotFound();
            }
            return View(yearterm);
        }

        // POST: /YearTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="YearTermId,Year,Term,IsDefault")] YearTerm yearterm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearterm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearterm);
        }

        // GET: /YearTerm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearterm = db.YearTerms.Find(id);
            if (yearterm == null)
            {
                return HttpNotFound();
            }
            return View(yearterm);
        }

        // POST: /YearTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearTerm yearterm = db.YearTerms.Find(id);
            db.YearTerms.Remove(yearterm);
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
