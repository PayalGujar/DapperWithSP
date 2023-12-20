using DapperWithSP.Models;
using DapperWithSP.Repository;

namespace DapperWithSP.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepo repo;

        public BookService(IBookRepo repo)
        {
            this.repo= repo;
        }
        public Task<int> AddBook(Book book)
        {
            return repo.AddBook(book);
        }

        public Task<int> DeleteBook(int id)
        {
           return repo.DeleteBook(id);
        }

        public Task<Book> GetBookById(int id)
        {
          return repo.GetBookById(id);
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
           return repo.GetBooks();
        }

        public Task<int> UpdateBook(Book book)
        {
           return repo.UpdateBook(book);
        }
    }
}
