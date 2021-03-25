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
        // get student with certain id in database ( row number ) - nie było w treśći zadania ale jak już zrobiłęm to uznałem, że nie ma co usuwać
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

        // get all students from database or take only student with certain indexNumber
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
                    return BadRequest("Nie ma takiego studenta w bazie");
                }
            }
            else
            {
                return BadRequest("Brak wczytania danych");
            }

            //2xx - ok
            //3xx - blad po stronie klienta
            //5xx - wewnętrzny błąd serwera // internal server error
        }
        //HttpPost - wstawienie rekordów. Przy potwarzającycm się ID nie dodaj do bazy
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            string temp =_studentService.parseStudentToString(student);
            _studentService.saveToDatabase(temp);

            return Ok(student);
        }
        //HttpPut
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            if(_studentService.isAlreadyInDatabase(student))
            {
                _studentService.updateStudentInDatabase(student);
            }

            return Ok("Wykonano update");
        }
        //HttpDelete - 
        [HttpDelete("{IndexNumber}")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            _studentService.deleteStudent(indexNumber);

            return Ok("Wykonano delete");
        }


    }
}
