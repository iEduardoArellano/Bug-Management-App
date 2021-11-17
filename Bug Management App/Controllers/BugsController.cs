using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Controllers
{
    public class BugsController : Controller
    {
        // GET: Bugs
        public ActionResult BugsForm()
        {
            return View();
        }
        public ActionResult BugsIndex()
        {
            return View();
        }
    }
}