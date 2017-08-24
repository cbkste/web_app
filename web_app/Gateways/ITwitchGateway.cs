using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Gateways.Responses;
using web_app.Helpers;
using web_app.ViewModels;

namespace web_app.Gateways
{
    public interface ITwitchGateway
    {
        Task<Response<TwitchTopClipsForGame>> GetTrendingClipsForGame(string game);
    }
}
