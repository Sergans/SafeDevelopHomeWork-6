using SafeDevelopLesson_6_1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SafeDevelopLesson_6_1.Data
{
    public class BookOperation : IBookService
    {
        private readonly IMongoCollection<BookModel> _book;
        public BookOperation(BookContext setting)
        {
            MongoClient client = new MongoClient(setting.ConnectionString);
            IMongoDatabase database = client.GetDatabase(setting.DataBase);
            _book= database.GetCollection<BookModel>(setting.Collection);
        }
        public void Create(BookModel book)
        {
            _book.InsertOne(book);
        }

        public void Delete(string id)
        {
           _book.DeleteOne(book=>book.Id==id);
        }

        public List<BookModel> GetAll()
        {
            return _book.Find(book => true).ToList();
        }

        public BookModel GetById(string id)
        {
            var books = GetAll();
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public void Update(string id,BookModel book)
        {
           _book.ReplaceOne(book => book.Id == id,book);
        }
    }
}
