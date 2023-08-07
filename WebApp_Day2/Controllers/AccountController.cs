using Microsoft.AspNetCore.Mvc;
using WebApp_Day2.Models;
using WebApp_Day2.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Day2.Controllers
{
    public class AccountController : Controller
    {
        ITIContext context;
        public AccountController()
        {
            context = new ITIContext();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            AddStudentVM studentVM = new AddStudentVM();
            studentVM.departments = new SelectList(context.Department, "ID", "Name");
            return View("AddStudent",studentVM);
        }
        [HttpPost]
        public IActionResult Registration(AddStudentVM studentVM)
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                studentVM.departments = new SelectList(context.Department.ToList(), "ID", "Name");
                return View(studentVM);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            // validate data
            if (ModelState.IsValid)
            {
                if (loginVM.IsAnInstructor)
                {
                    // check for values in DB for instructor

                    // save data in session
                }
                else
                {
                    // check for values in DB for student
                    Student student = context.Students.FirstOrDefault(s=>s.Emai == loginVM.Email && s.Password == loginVM.Password);
                    if(student == null)
                    {
                        ModelState.AddModelError("", "Wrong Email or password");
                        return View(loginVM);
                    }
                    // save data in session
                    HttpContext.Session.SetInt32("UserID", student.ID);
                    HttpContext.Session.SetString("UserName",student.Name); 
                    HttpContext.Session.SetString("UserType", "Student");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // return view with errors
                return View(loginVM);
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
