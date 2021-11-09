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
        private readonly IUsers _users;

        public BugsController(IBugs bugs, IUsers users)
        {
            _bugs = bugs;
            _users = users;
        }
        public ActionResult Index(int projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBug(Bugs bug, HttpPostedFileBase bugImage)
        {
            var currentUser = _users.GetUserByUserName(User.Identity.Name);

            if (ModelState.IsValid)
            {
                bug.CreationDate = DateTime.Today;
                bug.LastUpdateDate = DateTime.Today;
                bug.ReportedByUser = currentUser.Id;
                if (bugImage != null)
                {
                    bug.Image = new byte[bugImage.ContentLength];
                    bugImage.InputStream.Read(bug.Image, 0, bugImage.ContentLength);
                }
                _bugs.CreateBug(bug);
                _bugs.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private string SetImageData(byte[] bytesImage)
        {
            string base64Image = Convert.ToBase64String(bytesImage);

            return string.Format("data:image/png;base64,{0}", base64Image);
        }
    }
}