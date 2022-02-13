using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopLesson_6_1.Models;

namespace SafeDevelopLesson_6_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok();
        }
        [HttpPost]
        public IActionResult Add([FromBody]BookModel model)
        {
           return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult UpDate()
        {
            return Ok();
        }
    }
}
