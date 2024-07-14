using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Entities
{
    public class RegisterUser
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public bool Cloak { get; set; }
    }
}
