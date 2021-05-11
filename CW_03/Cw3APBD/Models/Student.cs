using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3APBD.Models
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string index { get; set; }
        public string studies { get; set; }
        public string mode { get; set; }
        public DateTime birthDate { get; set; }
        public string fathersName { get; set; }
        public string mothersName { get; set; }
        public string email { get; set; }

        public static Student parseFromCsv(string line)
        {
            Student temp = new Student();
            string[] fields = line.Split(',');
            temp.firstName = fields[0];
            temp.lastName = fields[1];
            temp.index = fields[2];
            temp.birthDate = parseDate(fields[3]);
            temp.studies = fields[4];
            temp.mode = fields[5];
            temp.email = fields[6];
            temp.fathersName = fields[7];
            temp.mothersName = fields[8];

            return temp;
        }
        public static List<Student> parseFromCsv(List<string> data)
        {
            List<Student> list = new List<Student>();
            foreach(string line in data)
            {
                Student temp = new Student();
                string[] fields = line.Split(',');
                temp.firstName = fields[0];
                temp.lastName = fields[1];
                temp.index = fields[2];
                temp.birthDate = parseDate(fields[3]);
                temp.studies = fields[4];
                temp.mode = fields[5];
                temp.email = fields[6];
                temp.fathersName = fields[7];
                temp.mothersName = fields[8];
                list.Add(temp);
            }

            return list;
        }
        static DateTime parseDate(string data)
        {
            string[] date = data.Split('/');
            DateTime temp = new DateTime(int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]));
            return temp;
        }

    }
    
}
