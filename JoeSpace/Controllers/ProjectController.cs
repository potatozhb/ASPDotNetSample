using JoeSpace.Data;
using JoeSpace.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoeSpace.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> projects = _db.Projects;

            return View(projects);
        }

        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project obj)
        {
            if (obj.ProjectName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Project name can't same as DisplayOrder");
            }
            //valid data in server
            if (ModelState.IsValid)
            {
                _db.Projects.Add(obj);
                _db.SaveChanges();
                TempData["success"] ="Project created success.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id== null|| id==0)
            {
                return NotFound();
            }
            var ProjectsFromDb = _db.Projects.Find(id);
            //var ProjectsFromDbFirst = _db.Projects.FirstOrDefault(u=>u.ID==id);
            //var ProjectsFromDbSingle = _db.Projects.SingleOrDefault(u=>u.ID==id);

            //Entity framework call
            if (ProjectsFromDb ==null)
            {
                return NotFound();
            }
            return View(ProjectsFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Project obj)
        {
            if (obj.ProjectName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Project name can't same as DisplayOrder");
            }
            //valid data in server
            if (ModelState.IsValid)
            {
                _db.Projects.Update(obj);
                _db.SaveChanges();
                TempData["success"] ="Project edited success.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id== null|| id==0)
            {
                return NotFound();
            }
            var ProjectsFromDb = _db.Projects.Find(id);
            //var ProjectsFromDbFirst = _db.Projects.FirstOrDefault(u=>u.ID==id);
            //var ProjectsFromDbSingle = _db.Projects.SingleOrDefault(u=>u.ID==id);

            //Entity framework call
            if (ProjectsFromDb ==null)
            {
                return NotFound();
            }
            return View(ProjectsFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id== null|| id==0)
            {
                return NotFound();
            }
            var ProjectsFromDb = _db.Projects.Find(id);
            //var ProjectsFromDbFirst = _db.Projects.FirstOrDefault(u=>u.ID==id);
            //var ProjectsFromDbSingle = _db.Projects.SingleOrDefault(u=>u.ID==id);

            //Entity framework call
            if (ProjectsFromDb ==null)
            {
                return NotFound();
            }
            _db.Projects.Remove(ProjectsFromDb);
            _db.SaveChanges();
            TempData["success"] ="Project deleted success.";
            return RedirectToAction("Index");
        }
    

    }
}
