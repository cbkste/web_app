using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Config;
using web_app.Model;

namespace web_app.Repository
{
    public interface ILocalDbRepository
    {
        IConnectionHelper GetConnection();
        IEnumerable<UserData> GetData(string userId);
    }
}
