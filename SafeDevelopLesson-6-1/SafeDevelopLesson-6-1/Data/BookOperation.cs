using SafeDevelopLesson_6_1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SafeDevelopLesson_6_1.Data
{
    public class BookOperation : IBookService
    {
        public void Create(BookModel book)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookModel book)
        {
            throw new NotImplementedException();
        }
    }
}
