using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.ContentfulModels
{
    public class ContenfulCarousel : IContentfulModel
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public Asset Image { get; set; } = new Asset();
        public SystemProperties Sys { get; set; } = new SystemProperties();
    }
}
