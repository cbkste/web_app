using System.Data;

namespace web_app.Config
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
