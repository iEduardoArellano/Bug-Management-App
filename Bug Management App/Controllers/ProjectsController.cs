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
                imagesData.Add(SetImageData(i.Logo));
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
                _projects.SaveProjectsChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Projects editedProject, HttpPostedFile imageLogo)
        {

            if (ModelState.IsValid)
            {
                if (imageLogo != null)
                {
                    editedProject.Logo = new byte[imageLogo.ContentLength];
                    imageLogo.InputStream.Read(editedProject.Logo, 0, imageLogo.ContentLength);
                }
                var project = _projects.FindProjectById(editedProject.ProjectId);

                project.ProjectName = editedProject.ProjectName;
                project.CompanyName = editedProject.CompanyName;
                project.Logo = editedProject.Logo;
                project.ProjectManager = editedProject.ProjectManager;
                project.Status = editedProject.Status;
            }
            

            _projects.SaveProjectsChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SendProjecToEdit(int projectId)
        {
             var project = _projects.FindProjectById(projectId);
             ViewBag.ImageData = SetImageData(project.Logo);
            //return RedirectToRoute("Edit", project);

            return View("Edit", project);
        }

        public ActionResult Delete(int projectId)
        {
            _projects.DeleteProject(projectId);
            _projects.SaveProjectsChanges();

            return RedirectToAction("Index");
        }

        private string SetImageData(byte[] bytesImage)
        {
            string base64Image = Convert.ToBase64String(bytesImage);

            return string.Format("data:image/png;base64,{0}", base64Image);
        }

        
    }
}