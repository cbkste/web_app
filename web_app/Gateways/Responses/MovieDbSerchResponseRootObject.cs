using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.ViewModels;

namespace web_app.Gateways.Responses
{
    public class MovieDbSerchResponseRootObject
    {
        public List<MovieDbSerchResponse> results { get; set; }
    }
}
