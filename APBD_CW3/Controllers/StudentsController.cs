using APBD_CW3.DAL;
using APBD_CW3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CW3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _dbService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            var student = _dbService.GetStudent(indexNumber);
            if (student is null) { 
            return NotFound($"Student o numerze indeksu {indexNumber} nie istnieje");

           } else
            return Ok(student);
        }


        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _dbService.AddStudent(student);

            return Created("Student stworzony", student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult deleteStudent(string indexNumber)
        {
            _dbService.DeleteStudent(indexNumber);
            return Ok($"Student o numerze indeksu {indexNumber} został usunięty");

        }

        [HttpPut("{indexNumber}")]
        public IActionResult updateStudent([FromBody] Student student)
        {
            _dbService.UpdateStudent(student);
            return Ok($"Student o numerze indeksu {student.IndexNumber} zaktualizowany");
        }
    }
}
