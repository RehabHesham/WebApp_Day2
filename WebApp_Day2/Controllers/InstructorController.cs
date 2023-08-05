using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_Day2.Models;

namespace WebApp_Day2.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext context;
        public InstructorController()
        {
            context = new ITIContext();
        }
        // Get all
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.Include(i => i.Department).ToList();
            return View(instructors);
        }
        public IActionResult GetByID(int id)
        {
            Instructor instructor = context.Instructors.Include(i => i.Department).SingleOrDefault(i=>i.ID==id);
            return View(instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Department> departments = context.Department.ToList();
            ViewBag.departments = new SelectList(departments,"ID","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i=>i.ID==id);
            List<Department> departments = context.Department.ToList();
            ViewBag.departments = new SelectList(departments, "ID", "Name");
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            Instructor OldInctructor = context.Instructors.SingleOrDefault(i => i.ID == instructor.ID);
            OldInctructor.Name = instructor.Name;
            OldInctructor.Age = instructor.Age;
            OldInctructor.Emai = instructor.Emai;
            OldInctructor.Salary = instructor.Salary;
            OldInctructor.dept_id = instructor.dept_id;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.ID == id);
            context.Instructors.Remove(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
