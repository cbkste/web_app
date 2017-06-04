using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Config
{
    public class TheMovieDbApiConfiguration
    {
        public string ApiBaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string ImageApiBaseUrl { get; set; }
        public List<string> BackdropSizes { get; set; }
    }
}
