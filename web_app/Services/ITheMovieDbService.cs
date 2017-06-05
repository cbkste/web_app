using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Gateways;
using web_app.Gateways.Responses;
using web_app.ViewModels;

namespace web_app.Services
{
   public interface ITheMovieDbService
    {
        Task<MovieDbSearchViewModel> getSingleMovieInformation(int movieId);
    }
}
