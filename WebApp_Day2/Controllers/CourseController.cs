using Microsoft.AspNetCore.Mvc;
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
        // Get All
        public IActionResult Index()
        {
            List<Course> courses = context.Courses.ToList();

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
