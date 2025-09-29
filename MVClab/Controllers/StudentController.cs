using Microsoft.AspNetCore.Mvc;
using MVClab.Context;

namespace MVClab.Controllers
{
    public class StudentController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult getAll()
        {
            ContentResult res = new ContentResult();
                var students = db.Students.ToList();

            return View("index",students);
        }
        public IActionResult getOne(int ssn) 
        {
            var student = db.Students.SingleOrDefault(s => s.SSN == ssn);

            return View("getStud",student);
        }
    }
}
