using Contentful.Core.Models;

namespace web_app.ContentfulModels
{
    public interface IContentfulModel
    {
        SystemProperties Sys { get; set; }
    }
}
