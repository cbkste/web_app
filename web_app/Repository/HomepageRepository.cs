using Contentful.Core;
using Contentful.Core.Search;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using web_app.Client;
using web_app.Config;
using web_app.ContentfulFactories;
using web_app.ContentfulModels;
using web_app.Http;
using web_app.Model;

namespace web_app.Repository
{
    public class HomepageRepository
    {
        private readonly IContentfulClient _client;
        private readonly IContentfulFactory<ContentfulHomepage, Homepage> _homepageFactory;

        public HomepageRepository(IOptions<ContenfulClientConfiguration> config, IContentfulClientManager clientManager, IContentfulFactory<ContentfulHomepage, Homepage> homepageFactory)
        {
            _client = clientManager.GetClient(config);
            _homepageFactory = homepageFactory;
        }

        public async Task<HttpResponse> Get()
        {
            var builder = new QueryBuilder<ContentfulHomepage>().ContentTypeIs("homepage").Include(3);
            var entries = await _client.GetEntriesAsync(builder);
            var entry = entries.FirstOrDefault();

            return entry == null
                ? HttpResponse.Failure(HttpStatusCode.NotFound, $"No homepage found")
                : HttpResponse.Successful(_homepageFactory.ToModel(entry));
        }
    }
}
