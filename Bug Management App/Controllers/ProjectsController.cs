using Bug_Management_App.Data;
using Bug_Management_App.Dtos;
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
    public class ProjectsController : Controller
    {
        private IProjects _projects;

        public ProjectsController(IProjects projects)
        {
            _projects = projects;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProjectDto createProject, HttpPostedFileBase imageLogo)
        {
            if (ModelState.IsValid)
            {
                if (imageLogo != null)
                {
                    createProject.Logo = new byte[imageLogo.ContentLength];
                    imageLogo.InputStream.Read(createProject.Logo, 0 ,imageLogo.ContentLength);
                }

                var mappedCreateProject = AutoMap._mapper.Map<Projects>(createProject);
                _projects.CreateProject(mappedCreateProject);

                return RedirectToAction("Index");
            }

            return View();
        }

        
        //[HttpGet]
        public ActionResult Index()
        {
            List<Projects> projects =_projects.GetProjectsInDb().ToList();
            foreach (var i in projects)
            {
                i.Logo = this.ConvertImage(Convert.ToBase64String(i.Logo));
            }

            return View(projects);
        }

        private byte[] ConvertImage(string imageBase64)
        {
            byte[] bytes;

            bytes = Convert.FromBase64String(imageBase64);

            return bytes;
        }
    }
}