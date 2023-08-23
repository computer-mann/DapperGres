using Npgsql;
using System.Data;

namespace DapperWeb.ORM
{
    public class DapperConnectionFactory:ISqlConnectionFactory
    {
        private readonly string _connectionString;
        public DapperConnectionFactory(IConfiguration configuration)
        {
           _connectionString= configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException("Invalid db connection string");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }

    public interface ISqlConnectionFactory
    {
        public IDbConnection CreateConnection();
    }

  
}
