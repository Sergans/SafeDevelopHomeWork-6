using SafeDevelopLesson_6_1.Models;

namespace SafeDevelopLesson_6_1.Data
{
    public interface IBookService
    {
        void Create(BookModel book);
        BookModel GetById(int id);
        List<BookModel> GetAll();
        void Delete(int id);
        void Update(BookModel book);
    }
}
