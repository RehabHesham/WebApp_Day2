using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Day2.Models
{
    [PrimaryKey("Std_ID","Crs_ID")]
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int Std_ID { get; set; }
        [ForeignKey("Course")]
        public int Crs_ID { get; set; }

        public int Grade { get; set; }

        // Navigation Property
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
