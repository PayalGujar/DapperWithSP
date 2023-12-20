using Dapper;
using DapperWithSP.Data;
using DapperWithSP.Models;
using System.Data;

namespace DapperWithSP.Repository
{
    public class BookSPRepo : IBookRepo
    {
        private readonly ApplicationDbContext context;

        public BookSPRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddBook(Book book)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            using(var connection=context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_InsertBook", parameters, commandType: CommandType.StoredProcedure); 
            }
            return result;
        }

        public async Task<int> DeleteBook(int id)
        {
            int result = 0;
            var parameters= new DynamicParameters();
            parameters.Add("@id", id);
            using(var connection=context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_DeleteBook", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
           using(var connection  = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Book>("SP_book_GetBookById", new { id },commandType:CommandType.StoredProcedure);
                return result;
            }


        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
           using(var connection=context.CreateConnection())
            {
                var result = await connection.QueryAsync<Book>("SP_book_GetBooks", commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<int> UpdateBook(Book book)
        {
            int result = 0;
            var parameters=new DynamicParameters();
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            parameters.Add("@id", book.Id);
            using(var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_UpdateBook", parameters,commandType: CommandType.StoredProcedure);
            }
            return result;


        }
    }
}
