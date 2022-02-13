using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopLesson_6_1.Models;
using SafeDevelopLesson_6_1.Data;

namespace SafeDevelopLesson_6_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookOperation _book;
        public BookController(BookOperation book)
        {
            _book = book;
        }
        [HttpGet]
        public IActionResult Get()
        {
          return Ok(_book.GetAll());
        }
        [HttpPost]
        public IActionResult Add([FromBody]BookModel model)
        {
           _book.Create(model);
           return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery]string id)
        {
            _book.Delete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpDate([FromBody] BookModel book)
        {
            _book.Update(book.Id, book);
            return Ok();
        }
    }
}
