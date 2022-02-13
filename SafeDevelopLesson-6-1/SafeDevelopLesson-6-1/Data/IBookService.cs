using SafeDevelopLesson_6_1.Models;

namespace SafeDevelopLesson_6_1.Data
{
    public interface IBookService
    {
        void Create(BookModel book);
        BookModel GetById(string id);
        List<BookModel> GetAll();
        void Delete(string id);
        void Update(string id,BookModel book);
    }
}
