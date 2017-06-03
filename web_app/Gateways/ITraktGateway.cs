using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Gateways
{
    public interface ITraktGateway
    {
        Task<object> getLastWatched();
    }
}
