using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.ViewModels
{
    public class Image
    {
        public string cssClass { get; }
        public string url { get; }

        public Image(string cssclass, string imageUrl)
        {
            cssClass = cssclass;
            url = $"https:{imageUrl}";
        }
    }
}
