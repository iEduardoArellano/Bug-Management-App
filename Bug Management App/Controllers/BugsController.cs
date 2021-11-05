using Bug_Management_App.Interfaces;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Controllers
{
    [Authorize]
    public class BugsController : Controller
    {
        private readonly IBugs _bugs;

        public BugsController(IBugs bugs)
        {
            _bugs = bugs;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBug(Bugs bug)
        {
            if (ModelState.IsValid)
            {
                _bugs.CreateBug(bug);
                _bugs.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}