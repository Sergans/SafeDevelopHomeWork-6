using Nest;
using SafeDevelopLesson_6_1.Models;

namespace SafeDevelopLesson_6_1.Data
{
    public class SearchBook
    {
        private readonly BookOperation _book;
        private readonly IEnumerable<BookModel> _books;
        private readonly ElasticClient _client;
        public SearchBook(BookOperation book)
        {
            _book = book;
            _books= _book.GetAll();
             var node = new Uri("http://localhost:9200/");
             var settings = new ConnectionSettings(node);
            _client = new ElasticClient(settings.DefaultIndex("people"));
            _client.IndexMany(_books);
        }
        public IEnumerable<BookModel> Search(string search)
        {
            var searchresponse = _client.Search<BookModel>(s => s.AllIndices().From(0).Size(10).Query(q => q.Match(m => m.Field(f => f.Autor).Query(search))));
            var bk = searchresponse.Documents;
            return bk;
        }
        public void AddDocument(BookModel book)
        {
            _client.IndexDocument(book);
        }
        

    }
}
