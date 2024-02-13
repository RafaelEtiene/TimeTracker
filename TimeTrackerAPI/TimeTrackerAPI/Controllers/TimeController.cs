using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Services.Time;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        [Route("GetTotalTimeTask/{idTask}")]
        public async Task<IActionResult> GetTotalTimeTask(int idTask)
        {
            try
            {
                var result = await _timeService.GetTotalTimeTask(idTask);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetWorkedTimeOfDay")]
        public async Task<IActionResult> GetWorkedTimeOfDay()
        {
            try
            {
                var result = await _timeService.GetWorkedTimeOfDay();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetWorkedTimeOfMonth")]
        public async Task<IActionResult> GetWorkedTimeOfMonth()
        {
            try
            {
                var result = await _timeService.GetWorkedTimeOfMonth();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTimeByTask")]
        public async Task<IActionResult> GetTimeByTask()
        {
            try
            {
                var result = await _timeService.GetTimeByTask();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("InsertTime")]
        public async Task<IActionResult> InsertTime([FromBody] Domain.Entities.Time request)
        {
            try
            {
                var result = await _timeService.InsertTime(request);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
