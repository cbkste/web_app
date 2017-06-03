using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Gateways.Responses;
using web_app.Helpers;

namespace web_app.Gateways
{
    public interface ITheMovieDbGateway
    {
        Task<Response<MovieDbSerchResponseRootObject>> GetMovieInfo(string movie);
    }
}
