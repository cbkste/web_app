using System.Collections.Generic;
using web_app.Gateways.Responses;

namespace web_app.ViewModels
{
    public class MovieDbSearchViewModel
    {
        public MovieViewModel movieResults { get; set; }
        public CastAndCrew cast { get; set; }
    }
}
