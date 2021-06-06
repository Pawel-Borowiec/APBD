using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_12.Models
{
    public class Student
    {
        public int idStudent { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime  BirthDate { get; set; }
        public string Studies { get; set; }
        public string Avatar { get; set; }
    }
}
