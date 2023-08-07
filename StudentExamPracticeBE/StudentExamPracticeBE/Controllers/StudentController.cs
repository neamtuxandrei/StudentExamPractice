using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.DataAccess;
using StudentExamPracticeBE.Domain;
using System.ComponentModel.DataAnnotations;
using System.Data;

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
        //  [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound("Student not found.");
                return Ok(student);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }

        }
        //  [Authorize(Roles = "Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            try
            {
                IEnumerable<Student> students = await _studentService.GetAllStudents();
                return Ok(students.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
        // [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Student studentToInsert)
        {
            if (studentToInsert is null)
                return BadRequest("Student is null");
            _studentService.InsertStudent(studentToInsert.FirstName, studentToInsert.LastName,
                 studentToInsert.EmailAddress, studentToInsert.Tasks);
            await _studentService.SaveChangesAsync();
            // a better way?
            var student = await _studentService.GetStudentByEmail(studentToInsert.EmailAddress);
            return CreatedAtRoute("GetStudentById", new { id = student.Id }, student);

        }
        //[Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveStudent(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var student = await _studentService.GetStudentById(id);
                if (student == null)
                    return NotFound("Student not found.");
                _studentService.DeleteStudent(student);
                await _studentService.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }
    }
}
