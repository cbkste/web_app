using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.ContentfulModels;
using web_app.Model;

namespace web_app.ContentfulFactories
{
    public class FeaturedNewsFactory : IContentfulFactory<ContentfulFeaturedNews, News>
    {
        public News ToModel(ContentfulFeaturedNews news)
        {
            var title = news.Title ?? string.Empty;
            var slug = news.Slug ?? string.Empty;
            var desciption = news.Description ?? string.Empty;
        
            return new News(slug, title, desciption);
        }
    }
}
