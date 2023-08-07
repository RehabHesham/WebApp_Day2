using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_Day2.Models;

namespace WebApp_Day2.ViewModels
{
    public class AddStudentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Name must be from 5 to 50 char")]
        public string Name { get; set; }
        [Range(20,35,ErrorMessage ="Age must be from 20 to 35")]
        public int Age { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="You must give a valid email")]
        [EmailAddress()]
        public string Emai { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$",ErrorMessage = "You must match regex At least one digit [0-9]\r\nAt least one lowercase character [a-z]\r\nAt least one uppercase character [A-Z] At least 8 characters in length, but no more than 32.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$", ErrorMessage = "You must match regex At least one digit [0-9]\r\nAt least one lowercase character [a-z]\r\nAt least one uppercase character [A-Z] At least 8 characters in length, but no more than 32.")]
        [Compare("Password",ErrorMessage ="Password must match confirm password")]
        public string ConfirmPassword { get; set; }
        [MinLength(5,ErrorMessage ="address must be more than 5 char")]
        public string Address { get; set; }
        [Display(Name ="Department")]
        public int Dept_ID { get; set; }

        [ValidateNever]
        public SelectList departments { get; set; }
    }
}
