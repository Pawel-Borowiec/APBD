using Cw3APBD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3APBD.Service
{
    public class studentService
    {
        const string SOURCEPATH = @".\Datas\students.csv";

        public bool isCsvExist()
        {
            if (System.IO.File.Exists(SOURCEPATH))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string parseStudentToString(Student student)
        {
            return student.firstName + "," + student.lastName + "," + student.index + ","
                + student.birthDate.Month + "/" + student.birthDate.Day+ "/" + student.birthDate.Year + ","
                + student.studies + "," + student.mode + ","
                + student.email + "," + student.fathersName + "," + student.mothersName;
        }

        public List<Student> getAllStudents()
        {
            List<string> data = new List<string>(System.IO.File.ReadAllLines(SOURCEPATH));
            return Student.parseFromCsv(data);
        }
        public void saveToDatabase(string student)
        {
            if (!File.Exists(SOURCEPATH))
            {
                File.Create(SOURCEPATH).Dispose();
            }
            List<string> data = new List<string>(File.ReadAllLines(SOURCEPATH));

            using (StreamWriter sw = File.AppendText(SOURCEPATH))
            {
                if (!isAlreadyInDatabase(student,data))
                {
                    sw.WriteLine(student);
                }
            }
        }
        public bool isAlreadyInDatabase(string student, List<string> data)
        {
            string[] fields = student.Split(",");
            foreach(string x in data)
            {
                string[] temp = x.Split(",");
                if (temp[2].Equals(fields[2]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool isAlreadyInDatabase(string indexNumber)
        {
            List<string> data = new List<string>(File.ReadAllLines(SOURCEPATH));
            foreach (string x in data)
            {
                string[] temp = x.Split(",");
                if (temp[2].Equals(indexNumber))
                {
                    return true;
                }
            }
            return false;
        }
        public bool isAlreadyInDatabase(Student student)
        {
            var temp = getAllStudents();
            foreach(Student x in temp)
            {
                if (x.index.Equals(student.index))
                {
                    return true;
                }
            }
            return false;
        }

        public void updateStudentInDatabase(Student student)
        {
            if (System.IO.File.Exists(SOURCEPATH))
            {

                List<string> data = new List<string>(System.IO.File.ReadAllLines(SOURCEPATH));
                var temp = Student.parseFromCsv(data);
                var toUpdate = new Student();
                foreach (Student x in temp)
                {
                    if (x.index.Equals(student.index))
                    {
                        toUpdate = x;
                    }
                }
                temp.Remove(toUpdate);
                toUpdate = student;
                temp.Add(toUpdate);

                using StreamWriter sw = File.CreateText(SOURCEPATH); foreach (Student x in temp)
                {
                    sw.WriteLine(parseStudentToString(x));
                }
            }
        }
        public void deleteStudent(string indexNumber)
        {
            if (!indexNumber.Equals(""))
            {
                var temp = getAllStudents();
                List<Student> toRemove = new List<Student>();
                foreach (Student x in temp)
                {
                    if (x.index.Equals(indexNumber))
                    {
                        toRemove.Add(x);
                    }
                }
                foreach (Student x in toRemove)
                {
                    temp.Remove(x);
                }
                using StreamWriter sw = File.CreateText(SOURCEPATH); foreach (Student x in temp)
                {
                    sw.WriteLine(parseStudentToString(x));
                }
            }
        }
    }
}
