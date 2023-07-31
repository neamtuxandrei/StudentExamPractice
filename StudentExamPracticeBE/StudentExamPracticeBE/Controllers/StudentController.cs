using Microsoft.AspNetCore.Mvc;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.DataAccess;
using StudentExamPracticeBE.Domain;
using System.ComponentModel.DataAnnotations;

namespace StudentExamPracticeBE.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var student = _studentService.GetStudent(id);
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            IEnumerable<Student> students = await _studentService.GetAllStudents();
            return Ok(students.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Student studentToInsert)
        {
            if (studentToInsert is null) throw new ValidationException($"Request {typeof(Student)} is null");
            await _studentService.InsertStudent(studentToInsert.FirstName, studentToInsert.LastName,
                 studentToInsert.EmailAddress, studentToInsert.Tasks);
            return Ok();
        }
    }
}
