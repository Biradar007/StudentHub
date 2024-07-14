using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace SH.ViewModels
{
    public class StudentInfoVM
    {
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string StudentName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string StudentEmail { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [MaxLength(10, ErrorMessage = "only 10 characters are allowed")]
        public string StudentPhone { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Display(Name = "Active Status")]
        [Required(ErrorMessage = "Status is required")]
        public bool StudentStatus { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public string Courses { get; set; }
        public bool Cloak { get; set; }
        public string[] CourseList { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(250, ErrorMessage = "only 250 characters are allowed")]
        public string Description { get; set; }
        public string ImgPath { get; set; }

        //public List<string> CourseList
        //{
        //    get
        //    {
        //        var res = JsonConvert.DeserializeObject<List<string>>(Courses);
        //        if (res != null)
        //        {
        //            return res;
        //        }
        //        else
        //        {
        //            return new List<string>();
        //        }
        //    }
        //    set
        //    {
        //        Courses = JsonConvert.SerializeObject(value);
        //    }
        //}

    }
}
