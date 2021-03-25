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
        readonly studentService _studentService = new studentService();

        // get student with certain id in database ( row number ) - nie było w treśći zadania ale jak już zrobiłęm to uznałem, że nie ma co usuwać
        [HttpGet("{rowNumber}")]
        public IActionResult GetStudents(int rowNumber)
        {
            if (_studentService.isCsvExist())
            {
                var students = _studentService.getAllStudents();
                return Ok(students[rowNumber-1]);
            }
            else
            {
                return StatusCode(404,"Nie odnaleziono pliku z danymi");
            }
        }

        // get all students from database or take only student with certain indexNumber
        [HttpGet]
        public IActionResult GetStudents(string indexNumber = "")
        {
            if (_studentService.isCsvExist())
            {
                if (indexNumber.Equals(""))
                {
                    return Ok(_studentService.getAllStudents());
                } else
                {
                    var temp = _studentService.getAllStudents();
                    foreach(Student x in temp)
                    {
                        if (x.index.Equals(indexNumber))
                        {
                            return Ok(x);
                        }
                    }
                    return StatusCode(404,"Nie ma takiego studenta w bazie");
                }
            }
            else
            {
                return StatusCode(404,"Błąd wczytania danych z bazy");
            }
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
                return Ok(student);
            }
            else
            {
                string temp = _studentService.parseStudentToString(student);
                _studentService.saveToDatabase(temp);
                return StatusCode(201,student);
            }

            
        }
        //HttpDelete - 
        [HttpDelete("{IndexNumber}")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            if (_studentService.isAlreadyInDatabase(indexNumber))
            {
                _studentService.deleteStudent(indexNumber);
                return Ok("Wykonano delete");
            }
            else
            {
                return StatusCode(404, "Nie ma takiego studenta w bazie");
            }
            
        }


    }
}
