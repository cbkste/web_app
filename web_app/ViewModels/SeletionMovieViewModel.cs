﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using web_app.Gateways.Responses;

namespace web_app.ViewModels
{
    public class SeletionMovieViewModel
    {
        public List<MovieDbSerchResponse> movieResults { get; set; }
    }
}
