﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.ContentfulModels;
using web_app.Model;

namespace web_app.ContentfulFactories
{
    public class HomepageContentfulFactory : IContentfulFactory<ContentfulHomepage, Homepage>
    {
        private readonly IContentfulFactory<ContentfulFeaturedNews, News> _featuredNewsFactory;

        public HomepageContentfulFactory(IContentfulFactory<ContentfulFeaturedNews, News> featuredNewsFactory)
        {
            _featuredNewsFactory = featuredNewsFactory;
        }

        public Homepage ToModel(ContentfulHomepage entry)
        {
            var backgroundImage = !string.IsNullOrEmpty(entry.BackgroundImage.File?.Url) ? entry.BackgroundImage.File.Url : string.Empty;
            var title = !string.IsNullOrEmpty(entry.Title) ? entry.Title : string.Empty;

            var featuredNewsItem =
                 entry.HiglightedNews
                    .Select(item => _featuredNewsFactory.ToModel(item)).ToList();

            return new Homepage(backgroundImage, title, featuredNewsItem);
        }
    }
}
