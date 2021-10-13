using Bug_Management_App.Dtos;
using Bug_Management_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bug_Management_App.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private IProjects _projects;

        public ProjectsController(IProjects projects)
        {
            _projects = projects;
        }

        public ActionResult Create()
        {
            return View("CreateProject");
        }

        [HttpPost]
        public ActionResult Create(CreateProjectDto createProject)
        {
            return RedirectToAction("CreateProject");
        }

        public ActionResult Index()
        {
            var projects =_projects.GetProjectsInDb();
            return View();
        }
    }
}