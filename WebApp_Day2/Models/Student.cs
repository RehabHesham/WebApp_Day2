namespace WebApp_Day2.Models
{
    public class Student : Person
    {
        public string Address { get; set; }

        // Navigation Property
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
