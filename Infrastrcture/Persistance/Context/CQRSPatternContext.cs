using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastrcture.Persistance.Context
{
    public class CQRSPatternContext
    {
        private readonly IConfiguration _configuration;

        public CQRSPatternContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            var database = _configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            return new SqlConnection(database?.ConnectionString);
        }
    }
}
