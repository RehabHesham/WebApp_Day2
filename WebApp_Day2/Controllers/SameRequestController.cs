using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Day2.Models;
using WebApp_Day2.ViewModels;

namespace WebApp_Day2.Controllers
{
    public class SameRequestController : Controller
    {
        ITIContext context;
        public SameRequestController()
        {
            context = new ITIContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewDataAction(string name, int age)
        {
            ViewData["name"] = name;
            ViewData["age"] = age;
            ViewData["arr"] = new int[] { 1, 2, 3, 4, 5, 6 };

            return View("ViewData");
        }


        public IActionResult ViewBagAction(string name, int age)
        {
            ViewBag.name = name;
            ViewBag.age = age;
            ViewBag.arr = new int[] { 1, 2, 3, 4, 5, 6 };

            ViewData["address"] = "Alex";
            ViewBag.location = "Giza";
            return View();
        }

        public IActionResult ModelAction(string name, int age)
        {
            // create object
            // anonymous object
            //var obj = new { Name = name, Age = age };
            //return View(obj);

            // object using class
            Person person = new Person() { Name=name,Age=age};
            return View(person);
        }

        public IActionResult ViewModelAction()
        {
            Course course = context.Courses.Include(c=>c.CourseStudents).ThenInclude(cs=>cs.Student).FirstOrDefault();


            CourseStudents students = new CourseStudents()
            {
                Crs_Id = course.ID,
                Crs_Name = course.Name
            };

            for(int i=0; i<course.CourseStudents.Count; i++)
            {
                students.stds.Add(new Students()
                {
                    Std_Id = course.CourseStudents[i].Std_ID,
                    Std_Name = course.CourseStudents[i].Student.Name,
                    Grade = course.CourseStudents[i].Grade
                });
            }
            return View(students);
        }
    }
}
