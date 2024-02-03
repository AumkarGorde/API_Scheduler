using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchdularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IQuartzService _quartzService;
        public ScheduleController(IQuartzService quartzService)
        {
            _quartzService = quartzService;
        }
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("API IS HEALTHY");
        }

        [HttpPost("schedule-test-job")]
        public async Task<IActionResult> ScheduleTestJob([FromBody] ScheduleRequest request)
        {
            try
            {
                await _quartzService.ScheduleTestJob(request);
                return Ok($"Job schedule for jobId : {request.JobId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        [HttpPost("schedule-polling-job")]
        public async Task<IActionResult> SchedulePollingJob([FromBody] ScheduleRequest request)
        {
            try
            {
                await _quartzService.SchedulePolling(request);
                return Ok($"Job schedule for jobId : {request.JobId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
