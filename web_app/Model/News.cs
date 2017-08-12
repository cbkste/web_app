using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Model
{
    public class News
    {
        public string Description { get; }
        public string Title { get; }
        public string Slug { get; }

        public News() { }

        public News(string slug, string title, string description)
        {
            Description = description;
            Title = title;
            Slug = slug;
        }
    }
}
