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
        private readonly IProjects _projects;

        public ProjectsController(IProjects projects)
        {
            _projects = projects;
        }

        //[HttpGet]
        public ActionResult Index()
        {
            List<Projects> projects = _projects.GetProjectsInDb().ToList();
            List<string> imagesData = new List<string>();

            foreach (var i in projects)
            {
                imagesData.Add(setImageData(i.Logo));
            }

            ViewBag.ImagesData = imagesData;
            return View(projects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int projectId)
        {
            Projects project = _projects.FindProjectById(projectId);

            return View(project);
        }

        public ActionResult Edit(Projects project)
        {
            if (ModelState.IsValid)
            {
                
            }
        }


        public string setImageData(byte[] bytesImage)
        {
            string base64Image = Convert.ToBase64String(bytesImage);

            return string.Format("data:image/png;base64,{0}", base64Image);
        }

        
    }
}