using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Day2.Models
{
    public class Student : Person
    {
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int Dept_ID { get; set; }

        // Navigation Property
        public List<StudentCourse> StudentCourses { get; set; }
        public Department Department { get; set; }

    }
}
