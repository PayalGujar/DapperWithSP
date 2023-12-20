using DapperWithSP.Models;

namespace DapperWithSP.Service
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);

        Task<int> AddBook(Book book);

        Task<int> UpdateBook(Book book);

        Task<int> DeleteBook(int id);
    }
}
