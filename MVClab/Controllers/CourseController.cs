using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVClab.Context;
using MVClab.Models;

namespace MVClab.Controllers
{
    public class CourseController : Controller
    {
        private readonly CompanyContext db;
        public CourseController(CompanyContext context )
        {
            db = context;   
        }

        public IActionResult Index()
        {
            var courses =db.Courses.ToList();
            return View(courses);
        }
       
        public IActionResult Details(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.Number == id);
            if (course == null) return NotFound();
            return View(course);
        }
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Course course)
        {
            if (course.Degree < course.MinDegree)
            {
                ModelState.AddModelError("Degree", " MinDegree Must Less");
            }
            bool nameExists = db.Courses.Any(c => c.crsName == course.crsName && c.Number != course.Number);
            if (nameExists)
            {
                ModelState.AddModelError("crsName", "Course Name Already Exists.");
            }
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);   
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        public IActionResult Edit(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.Number == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {

            if (id != course.Number) return BadRequest();
            if (course.Degree <= course.MinDegree)
            {
                ModelState.AddModelError("Degree", "Degree must be greater than MinDegree.");
            }
            bool nameExists = db.Courses.Any(c => c.crsName == course.crsName && c.Number != course.Number);
            if (nameExists)
            {
                ModelState.AddModelError("crsName", "Course name must be unique.");
            
            }
            if (ModelState.IsValid)
            {
                db.Courses.Update(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.Number == id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.Number == id);
            if (course == null) return NotFound();

            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}   
