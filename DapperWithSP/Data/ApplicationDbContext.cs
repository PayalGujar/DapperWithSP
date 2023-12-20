using Microsoft.Data.SqlClient;
using System.Data;
namespace DapperWithSP.Data
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("defaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
