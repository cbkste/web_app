using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Model
{
    public class Homepage
    {
        public string BackgroundImage { get; }
        public string Title { get; }
        public List<News> FeaturedNews { get; }
        public List<Carousel> Carousel { get; }

        public Homepage(string backgroundImage, string title, List<News> featuredNews, List<Carousel> carousel)
        {
            BackgroundImage = backgroundImage;
            Title = title;
            FeaturedNews = featuredNews;
            Carousel = carousel;
        }
    }
}
