using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVClab.Context;
using MVClab.Models;
using MVClab.Filters;
using MVClab.Repository;

namespace MVClab.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository deptRepo)
        {
            departmentRepository = deptRepo;
        }
        public IActionResult Index()
        {
            var departments = departmentRepository.Get();
               

            return View(departments);
        }

        
        public IActionResult Details(int id)
        {
            var dept = departmentRepository.GetByID(id);
                //.Include(d => d.Students)
                //.Include(d => d.Instructors)
                //.FirstOrDefault(d => d.DepartmentId == id);

            if (dept == null) return NotFound();
            return View(dept);
        }

        
        public IActionResult AddNew()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Department dept)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Add(dept);
                departmentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        
        public IActionResult Edit(int id)
        {
            var dept = departmentRepository.GetByID(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department dept)
        {
            if (id != dept.DepartmentId) return BadRequest();

            if (ModelState.IsValid)
            {
                departmentRepository.Update(dept);
                departmentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        
        public IActionResult Delete(int id)
        {
            var dept =departmentRepository.GetByID( id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dept = departmentRepository.GetByID(id);
            if (dept == null) return NotFound();

            departmentRepository.Delete(id);
            departmentRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add2()
        {
            return View();
        }

        [HttpPost]
        [CheckLocationFilter]
        [AddFooterFilter]
        public IActionResult Add2(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Add(department);
                departmentRepository.Save();
                return View(department);
            }

            return View(department);
        }

        public IActionResult TestError()
        {

            int zero = 0;          
            int x = 5 / zero;
            return Content("You’ll never see this ");
        }

    }
}
