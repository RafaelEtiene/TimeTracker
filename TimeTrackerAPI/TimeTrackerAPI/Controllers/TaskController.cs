using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Services.Task;
using TimeTrackerAPI.Services.Time;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskService.GetAllTasks();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertTask")]
        public async Task<IActionResult> InsertTask([FromBody]Domain.Entities.Task request)
        {
            try
            {
                var result = await _taskService.InsertTask(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody]Domain.Entities.Task request)
        {
            try
            {
                var result = await _taskService.UpdateTask(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTask/{idTask}")]
        public async Task<IActionResult> DeleteTask(int idTask)
        {
            try
            {
                var result = await _taskService.DeleteTask(idTask);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
