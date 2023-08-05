using System.ComponentModel.DataAnnotations;

namespace WebApp_Day2.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Emai { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
