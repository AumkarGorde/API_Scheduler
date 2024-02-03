using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            
        }
        [HttpGet("value/{id}")]
        public async Task<IActionResult> GetValue(string id)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 6);
            await Console.Out.WriteLineAsync($"Counter : {randomNumber} , for {id}");
            return Ok(randomNumber);
        }
    }
}
