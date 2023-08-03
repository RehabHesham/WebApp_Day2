using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Day2.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalHours { get; set; }
        public int FullMark { get; set; }
        [ForeignKey("Instructor")]
        public int? Ins_ID { get; set; }

        // Navigation Property
        public Instructor? Instructor { get; set; }
        public List<StudentCourse> CourseStudents { get; set; }
    }
}
