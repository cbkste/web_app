using Dapper;
using System.Collections.Generic;
using System.Linq;
using web_app.Config;
using web_app.Model;

namespace web_app.Repository
{
    public class LocalDbRepository : ILocalDbRepository
    {
        private readonly IDbConnectionProvider _dbConnectionFactory;

        public LocalDbRepository(IDbConnectionProvider dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IConnectionHelper GetConnection()
        {
            var underlyingConnection = _dbConnectionFactory.GetConnection();
            return new ConnectionHelper(underlyingConnection);
        }

        public IEnumerable<UserData> GetData(string userId)
        {
            using (var connection = _dbConnectionFactory.GetConnection())
            {
                const string sql = "SELECT UserId, " +
                                   "FROM UserTable " +
                                   "WHERE UserId=@userId";
                return connection.Query<UserData>(sql, new { userId }).ToList();
            }
        }

    }
}
