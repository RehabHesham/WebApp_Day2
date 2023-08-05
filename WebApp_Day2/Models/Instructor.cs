using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Day2.Models
{
    public class Instructor : Person
    {
        [Display(Name ="Net Salary")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int dept_id { get; set; }

        // Navigation Property
        public List<Course> Courses { get; set; }
        public Department Department { get; set; }
    }
}
