using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SH.ViewModels
{
    public class RegisterUserVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public bool Cloak { get; set; }
    }
}
