using DiplomaDataModel.Models;
using OptionWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptionWebsite.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Choice choice)
        {
            if (ModelState.IsValid)
            {
                choice.SelectionDate = DateTime.Now;
                db.Choices.Add(choice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");
                return View(choice);
            }
        }
    }
}