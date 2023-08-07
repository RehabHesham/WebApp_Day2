using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Day2.Models;

namespace WebApp_Day2.Controllers
{
    public class CourseController : Controller
    {
        ITIContext context;
        public CourseController()
        {
            context = new ITIContext();
        }
        /*
         CRUD
        C => Create (2 Action)
        R => Read (1)
        U => Update (2 Action)
        D => Delete (1 Action)
         */
        // Get All
        public IActionResult Index()
        {
            List<Course> courses;
            if (HttpContext.Session.GetString("UserType") == "Instructor")
            {
               courses = context.Courses.ToList();
            }
            else
            {
                int? id = HttpContext.Session.GetInt32("UserID");
                List<StudentCourse> courses1 = context.Students.Include(s=>s.StudentCourses).ThenInclude(sc=>sc.Course).Where(s=>s.ID==id).SelectMany(s=>s.StudentCourses).ToList();
                courses = new List<Course>();
                foreach(StudentCourse course in courses1)
                {
                    courses.Add(course.Course);
                }
            }
            return View(courses);
            //return View();                  // View Name =  ActionName(Index)        // Model =  null
            //return View(courses);           // View Name =  ActionName(Index)        // Model =  courses
            //return View("Index2");          // View Name =  Index2        // Model =  null
            //return View("Index2",courses);  // View Name =  Index2        // Model =  courses
        }
        public IActionResult GetById(int id)
        {
            Course course = context.Courses.SingleOrDefault(c => c.ID == id);
            if (course == null)
            {
                return Content("Course not valid");
            }
            return View(course);
        }


        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult AddToDB(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
                //List<Course> courses = context.Courses.ToList();
                //return View("Index",courses);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("Something went wrong");
            }
        }

        public IActionResult EditForm(int id) {
            Course course = context.Courses.SingleOrDefault(c => c.ID == id);
            return View(course);
        }
        public IActionResult EditInDB(Course course)
        {
            Course OldCourse = context.Courses.SingleOrDefault(c => c.ID == course.ID);
            OldCourse.Name = course.Name;
            OldCourse.Description = course.Description;
            OldCourse.FullMark = course.FullMark;   
            OldCourse.TotalHours = course.TotalHours;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Course course = context.Courses.SingleOrDefault(c => c.ID == id);
                context.Courses.Remove(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("Something went wrong");
            }
        }
    }
}
