using Contentful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Model
{
    public class Carousel
    {
        public string Title { get; }
        public string Text { get; }
        public string Image { get; }

        public Carousel() { }

        public Carousel(string title, string text, string image)
        {
            Text = text;
            Title = title;
            Image = image;
        }
    }
}
