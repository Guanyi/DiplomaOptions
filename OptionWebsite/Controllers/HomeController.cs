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
            if(!User.IsInRole("Admin"))
            {
                ViewBag.CurrentStudentId = User.Identity.Name;
            }
            
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Choice choice)
        {
            //YearTerm selectedYearTerm = db.YearTerms.SingleOrDefault(y => y.IsDefault == true);
            choice.YearTerm = db.YearTerms.SingleOrDefault(y => y.IsDefault == true);
            
            //check the input model is valid and duplicate rows with the same StudentId in the StudentOptionChoices is not allowed in the same YearTerm
            if (ModelState.IsValid && !db.Choices.Any(c => c.StudentId == choice.StudentId && c.YearTerm.YearTermId == choice.YearTerm.YearTermId))
            {
                choice.SelectionDate = DateTime.Now;
                //choice.YearTerm.YearTermId = selectedYearTerm.YearTermId;
                db.Choices.Add(choice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");
            return View(choice);
        }
    }
}