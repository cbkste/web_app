using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.ContentfulModels;
using web_app.Model;

namespace web_app.ContentfulFactories
{
    public class CarouselFactory : IContentfulFactory<ContenfulCarousel, Carousel>
    {
        public Carousel ToModel(ContenfulCarousel carosel)
        {
            var title = carosel.Title ?? string.Empty;
            var image = !string.IsNullOrEmpty(carosel.Image.File?.Url) ? carosel.Image.File.Url : string.Empty;
            var text = carosel.Text ?? string.Empty;

            return new Carousel(title, text, image);
        }
    }
}
