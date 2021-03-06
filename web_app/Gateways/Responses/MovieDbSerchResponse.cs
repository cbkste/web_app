﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Config;

namespace web_app.Gateways.Responses
{

    public class MovieDbSerchResponse
    {
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public List<object> genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public double popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public string BackdropPathUrl => String.Format("{0}original{1}", "http://image.tmdb.org/t/p/", backdrop_path);
    }
}
