namespace WebApp_Day2.Models
{
    public class Instructor : Person
    {
        public decimal Salary { get; set; }

        // Navigation Property
        public List<Course> Courses { get; set; }
    }
}
