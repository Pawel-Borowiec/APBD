using Cw3APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3APBD.Service
{
    public class studentService
    {
        public string parseStudentToString(Student student)
        {
            return student.firstName + "," + student.lastName + "," + student.index + ","
                + student.birthDate + "," + student.studies + "," + student.mode + ","
                + student.email + "," + student.fathersName + "," + student.mothersName;
        }
    }
}
