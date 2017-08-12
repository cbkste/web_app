using System;
using Contentful.Core.Models;
using web_app.Model;
using System.Collections.Generic;

namespace web_app.ContentfulModels
{
    public class ContentfulHomepage : IContentfulModel
    {
        public Asset BackgroundImage { get; set; } = new Asset();
        public string Title { get; set; } = string.Empty;
        public IEnumerable<ContentfulFeaturedNews> HiglightedNews { get; set; } = new List<ContentfulFeaturedNews>();
        public SystemProperties Sys { get; set; } = new SystemProperties();
    }
}
