using Microsoft.AspNetCore.Mvc;

namespace WebApp_Day2.Controllers
{
    public class DifferentRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetTempData(string name, int age)
        {
          
            TempData["name"] = name;
            TempData["age"] = age;
            return Content("Data have been saved.");
        }

        public IActionResult GetTempData()
        {
            TempData.Keep("name");
            return Content($"Data: Name={TempData["name"]}, Age={TempData.Peek("age")}");
        }
        public IActionResult GetTempData2()
        {
            return Content($"Data: Name={TempData["name"]}, Age={TempData["age"]}");
        }

        public IActionResult SetSessionData(string name, int age)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("age", age);  
            return Content("Data have been saved.");
        }
        public IActionResult GetSessionData()
        {
            return Content($"Data: Name={HttpContext.Session.GetString("name")}, Age={HttpContext.Session.GetInt32("age")}");
        }

        public IActionResult DeleteSessionData()
        {
           // HttpContext.Session.Remove("name");
            HttpContext.Session.Clear();
            return Content($"Data have been deleted");
        }
    }
}
