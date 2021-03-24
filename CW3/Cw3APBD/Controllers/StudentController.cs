using Cw3APBD.Models;
using Cw3APBD.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cw3APBD.Controllers
{  
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        studentService _studentService = new studentService();

        [HttpGet("{IndexNumber}")]
        public async Task<IActionResult> GetStudents(int indexNumber)
        {
            List<string> data;
            string sourcePath = @".\Datas\students.csv";
            if (System.IO.File.Exists(sourcePath))
            {
                data = new List<string>(await System.IO.File.ReadAllLinesAsync(sourcePath));
                var students = Student.parseFromCsv(data);
                return Ok(students[indexNumber-1]);
            }
            else
            {
                return Ok("Brak wczytania danych");
            }
        }

        //HttpPatch 
        [HttpGet]
        public IActionResult GetStudents(string indexNumber = "")
        {
            List<string> data;
            string sourcePath = @".\Datas\students.csv";
            if (System.IO.File.Exists(sourcePath))
            {
                if (indexNumber.Equals(""))
                {
                    data = new List<string>(System.IO.File.ReadAllLines(sourcePath));
                    return Ok(Student.parseFromCsv(data));
                } else
                {
                    data = new List<string>(System.IO.File.ReadAllLines(sourcePath));
                    var temp = Student.parseFromCsv(data);
                    foreach(Student x in temp)
                    {
                        if (x.index.Equals(indexNumber))
                        {
                            return Ok(x);
                        }
                    }
                    return Ok("Nie ma takiego studenta w bazie");
                }
            }
            else
            {
                return Ok("Brak wczytania danych");
            }

            //2xx - ok
            //3xx - blad po stronie klienta
            //5xx - wewnętrzny błąd serwera // internal server error
        }
        //HttpPost
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            string temp =_studentService.parseStudentToString(student);

            return Ok(student);
        }
        //HttpPut
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            //Put /api/students/s1234 - aktualizacja wszystkich zasobów

            return Ok();
        }
        //HttpDelete
        [HttpDelete]
        public IActionResult DeleteStudent(Student student)
        {
            //Delete /api/students/s1234 - usuwanie studenta

            return Ok();
        }

        //https://localhost:44339/api/students/?indexNumber=s1234


    }
}
