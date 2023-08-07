using Microsoft.AspNetCore.Mvc;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;

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
        public async Task<ActionResult<ExamTask>> GetTask(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var task = await _taskService.GetTaskById(id);
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
        public async Task<IActionResult> Insert([FromBody] ExamTask taskToInsert)
        {
            if (taskToInsert is null)
                return BadRequest("Student is null");
            _taskService.InsertTask(taskToInsert.Title, taskToInsert.Description);
            await _taskService.SaveChangesAsync();
            var task = await _taskService.GetTaskByTitle(taskToInsert.Title);
            return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);

        }
        //[Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveTask(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            try
            {
                var task = await _taskService.GetTaskById(id);
                if (task == null)
                    return NotFound("Task not found.");
                _taskService.DeleteTask(task);
                await _taskService.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }

    }
}
