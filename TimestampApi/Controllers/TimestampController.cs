using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimestampApi.Models;

namespace TimestampApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Timestamp")]
    public class TimestampController : Controller
    {
        private readonly TimeContext _context;

        public TimestampController(TimeContext context)
        {
            _context = context;
        }

        // GET: api/Timestamp
        [HttpGet]
        public async Task<IActionResult> GetTimestamps()
        {
            return Ok(_context.TimeStamp);
        }

        // GET: api/Timestamp/5
        [HttpGet("{date}")]
        public async Task<IActionResult> GetTimestamp([FromRoute] string date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime result;
            
            DateTime.TryParse(date, out result);            

            if(result == DateTime.MinValue)
            {
                return BadRequest(new ErrorMessage
                {
                    Error = "Invalid date format provided."
                });
            }

            _context.UserDate = result;
            return Ok(_context.TimeStamp);
        }
    }
}