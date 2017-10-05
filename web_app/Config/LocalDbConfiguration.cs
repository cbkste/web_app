using System.Data;
using System.Data.SqlClient;


namespace web_app.Config
{
    public class LocalDbConfiguration : IDbConnectionProvider
    {
            private readonly AppConfig _config;

            public LocalDbConfiguration(AppConfig config)
            {
                _config = config;
            }
                
            public IDbConnection GetConnection()
            {
                return new SqlConnection(_config.LocalDbConnString);
            }
    }
}
