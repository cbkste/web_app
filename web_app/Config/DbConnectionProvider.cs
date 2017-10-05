using System.Data;

namespace web_app.Config
{
    public abstract class DbConnectionProvider
    {
        protected readonly AppConfig AppConfig;
        protected DbConnectionProvider(AppConfig config)
        {
            AppConfig = config;
        }
    }
}