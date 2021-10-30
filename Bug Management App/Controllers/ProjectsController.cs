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
        private readonly IUsers _users;

        public ProjectsController(IProjects projects, IUsers users)
        {
            _projects = projects;
            _users = users;
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
                createProject.CreationDate = DateTime.Today;
                var currentUser = _users.GetUserByUserName(User.Identity.Name);
                createProject.Creator = currentUser.Id;

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
        public ActionResult Edit(Projects editedProject, HttpPostedFileBase imageLogo)
        {
            var project = _projects.GetProjectById(editedProject.ProjectId);
            if (ModelState.IsValid)
            {
                if (imageLogo != null)
                {
                    editedProject.Logo = new byte[imageLogo.ContentLength];
                    imageLogo.InputStream.Read(editedProject.Logo, 0, imageLogo.ContentLength);
                    project.Logo = editedProject.Logo;
                }
                project.ProjectName = editedProject.ProjectName;
                project.CompanyName = editedProject.CompanyName;
                project.ProjectManager = editedProject.ProjectManager;
                project.Status = editedProject.Status;
            }
            
            _projects.SaveProjectsChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SendProjecToEdit(int projectId)
        {
             var project = _projects.GetProjectById(projectId);
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

        public ActionResult SortProjects(int sortId)
        {
            List<Projects> projects = _projects.GetProjectsInDb().ToList();
            var userInSession = _users.GetUserByUserName(User.Identity.Name).Id;
            List<string> imagesData = new List<string>();
            
                switch (sortId)
                {
                    //Todos
                    case 0:

                    break;
                    //Fecha
                    case 1:
                        projects.Sort((x, y) => DateTime.Compare(y.CreationDate, x.CreationDate));
                    break;
                    //Name
                    case 2:
                        projects = projects.OrderBy(n => n.ProjectName).ToList();
                    break;
                    //Por mi
                    case 3:
                        projects = _projects.GetProjectsCreatedByUser(userInSession).ToList();
                    break;
            }

            foreach (var i in projects)
            {
                imagesData.Add(SetImageData(i.Logo));
            }

            ViewBag.ImagesData = imagesData;
            return View("Index", projects);
        }
    }
}