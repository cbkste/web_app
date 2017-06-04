using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.ViewModels
{
    public class SearchMovieViewModel
    {
        [Required]
        public string MovieTitle { get; set; }
        public bool HasErrors { get; set; }
    }
}
