using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVClab.Context;
using MVClab.Models;

namespace MVClab.Controllers
{
    public class InstructorController : Controller
    {
        private readonly CompanyContext db;

        public InstructorController(CompanyContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var instructors = db.Instructors
                .Include(i => i.Department)
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Course)
                .ToList();

            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = db.Instructors
                .Include(i => i.Department)
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Course)
                .FirstOrDefault(i => i.SSN == id);

            if (instructor == null) return NotFound();
            return View(instructor);
        }

        public IActionResult AddNew()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = db.Departments.ToList();
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            var instructor = db.Instructors.Find(id);
            if (instructor == null) return NotFound();

            ViewBag.Departments = db.Departments.ToList();
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Instructor instructor)
        {
            if (id != instructor.SSN) return BadRequest();

            if (ModelState.IsValid)
            {
                db.Instructors.Update(instructor);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = db.Departments.ToList();
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            var instructor = db.Instructors
                .Include(i => i.Department)
                .FirstOrDefault(i => i.SSN == id);

            if (instructor == null) return NotFound();
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = db.Instructors.FirstOrDefault(i => i.SSN == id);
            if (instructor == null) return NotFound();

            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
