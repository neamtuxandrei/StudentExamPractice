using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Contracts.Students;
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
        public ActionResult<Student> GetStudent(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var student = _studentService.GetStudentById(id);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertStudentRequest request)
        {
            if (request is null)
                return BadRequest("Student is null");
            await _studentService.InsertStudent(request.FirstName, request.LastName,
                 request.EmailAddress);
            return Ok();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveStudent(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                await _studentService.RemoveStudentById(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditStudent(Guid id, [FromBody] UpdateStudentRequest request)
        {
            try
            {
                if (request is null) throw new ValidationException($"Request {typeof(UpdateStudentRequest)} is null");
                await _studentService.UpdateStudent(id, request.FirstName, request.LastName, request.EmailAddress);
                return Ok();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}
