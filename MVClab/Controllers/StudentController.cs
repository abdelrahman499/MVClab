using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVClab.Context;
using MVClab.Models;
using MVClab.ViewModels;
using MVClab.Filters;
using MVClab.Repository;

namespace MVClab.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository studentRepository; 
        IDepartmentRepository departmentRepository;

        public StudentController(IStudentRepository studRepo, IDepartmentRepository deptRepo)
        {
            studentRepository = studRepo;
            departmentRepository = deptRepo;


        }
        public IActionResult Index()
        {
            var students = studentRepository.Get();
            return View(students);
        }
        [CheckUserFilter("Student")]    
        public IActionResult Details(int id)
        {
            var student = studentRepository.GetByID(id);
            if (student == null) return NotFound();
            return View(student);
        }
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Student s)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(s);
                studentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }

        public IActionResult Edit(int id)
        {
            var student = studentRepository.GetByID(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.SSN) return BadRequest();

            if (ModelState.IsValid)
            {
                studentRepository.Update(student);
                studentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = studentRepository.GetByID(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentRepository.GetByID(id);
            if (student == null) return NotFound();

            studentRepository.Delete(id);
            studentRepository.Save();
            return RedirectToAction(nameof(Index));
        }
        
    }   
}
