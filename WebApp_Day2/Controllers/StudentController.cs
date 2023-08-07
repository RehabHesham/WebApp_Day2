using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Day2.Models;

namespace WebApp_Day2.Controllers
{
    public class StudentController : Controller
    {
        ITIContext context;
        public StudentController()
        {
            context = new ITIContext();
        }

        // Read
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserID") != null)
            {
                List<Student> students = context.Students.Include(s => s.Department).ToList();
                return View(students);
            }
            return Unauthorized();
        }

        public IActionResult GetById(int id)
        {
            Student student = context.Students.Include(s => s.Department).SingleOrDefault(s => s.ID == id);
            return View(student);
        }

        // Create
        public IActionResult Add()
        {
            List<Department> departments = context.Department.ToList();
            ViewBag.Departments = departments;
            return View();
        }
        public IActionResult AddToDB(Student student)
        {
            try
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content($"Something went wrong\n {ex}");
            }
        }

        // Update
        public IActionResult Edit(int id)
        {
            Student student = context.Students.SingleOrDefault(s => s.ID == id);
            ViewBag.Departments = context.Department.ToList();
            return View(student);
        }
        public IActionResult EditInDB(Student student)
        {
            try
            {
                Student OldStudent = context.Students.SingleOrDefault(s => s.ID == student.ID);
                OldStudent.Name = student.Name;
                OldStudent.Address = student.Address;
                OldStudent.Age = student.Age;
                OldStudent.Emai = student.Emai;
                OldStudent.Dept_ID = student.Dept_ID;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content($"Something went wrong\n {ex}");
            }
        }

        // Delete
        public IActionResult Delete(int id)
        {
            try
            {
                Student student = context.Students.SingleOrDefault(s => s.ID == id);
                context.Students.Remove(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content($"Something went wrong\n {ex}");
            }
        }
    }
}
