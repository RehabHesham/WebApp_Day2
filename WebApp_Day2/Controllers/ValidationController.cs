using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Day2.Models;
using WebApp_Day2.ViewModels;

namespace WebApp_Day2.Controllers
{
    public class ValidationController : Controller
    {
        ITIContext context;
        public ValidationController()
        {
            context = new ITIContext();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            AddStudentVM vm = new AddStudentVM()
            {
                departments = new SelectList(context.Department.ToList(),"ID","Name")
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddStudent(AddStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student()
                {
                    ID = studentVM.ID,
                    Name = studentVM.Name,
                    Age = studentVM.Age,
                    Emai = studentVM.Emai,
                    Address = studentVM.Address,
                    Password = studentVM.Password,
                    Dept_ID = studentVM.Dept_ID,
                };
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                studentVM.departments = new SelectList(context.Department.ToList(), "ID", "Name");
                return View(studentVM);
            }
        }
    }
}
