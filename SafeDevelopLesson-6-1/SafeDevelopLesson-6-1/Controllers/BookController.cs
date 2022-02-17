using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using SafeDevelopLesson_6_1.Models;
using SafeDevelopLesson_6_1.Data;
using Nest;

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
        public IActionResult Add([FromQuery]string Name, [FromQuery] double Price, [FromQuery] string Autor)
        {
            var book = new BookModel()
            {
                Name = Name,
                Price = Price,
                Autor = Autor

            };
           _book.Create(book);
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
        [HttpPost("post")]
        public IActionResult ElasticGet([FromQuery]string search)
        {
            var books = _book.GetAll();
            var node = new Uri("http://localhost:9200/");
            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings.DefaultIndex("people"));
            var response=client.IndexMany(books);

            var searchresponse = client.Search<BookModel>(s => s.AllIndices().From(0).Size(10).Query(q=>q.Match(m=>m.Field(f=>f.Autor).Query(search))));
            var bk = searchresponse.Documents;

            return Ok(bk);
        }
    }
}
