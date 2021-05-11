using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class Student
    {
        public string Index { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string birthDate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }

        public override string ToString()
        {
            return "student: " + Index + " " + fName + " " + lName + " " + birthDate + " " + email + " " + mothersName + " " + fathersName + " Studies:" + studies.name+ " " +studies.mode+"\n" ;
        }
    }
}
