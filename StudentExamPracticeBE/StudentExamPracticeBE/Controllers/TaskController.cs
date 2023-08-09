using Microsoft.AspNetCore.Mvc;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Contracts.Tasks;
using StudentExamPracticeBE.Domain;
using System.ComponentModel.DataAnnotations;

namespace StudentExamPracticeBE.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        //  [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("{id}", Name = "GetTaskById")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ExamTask> GetTask(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var task = _taskService.GetTaskById(id);
                if (task == null)
                    return NotFound("Task not found.");
                return Ok(task);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }

        }
        //  [Authorize(Roles = "Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ExamTask>>> GetTasks()
        {
            try
            {
                IEnumerable<ExamTask> tasks = await _taskService.GetAllTasks();
                return Ok(tasks.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
        // [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] InsertTaskRequest request)
        {
            if (request is null)
                return BadRequest("Task is null");
            await _taskService.InsertTask(request.Title, request.Description);
            return Ok();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveTask(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                await _taskService.RemoveTaskById(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}/update", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditTask(Guid id, [FromBody] UpdateTaskRequest request)
        {
            try
            {
                if (request is null) throw new ValidationException($"Request {typeof(UpdateTaskRequest)} is null");
                await _taskService.UpdateTask(id, request.Title, request.Description);
                return Ok();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

    }
}
