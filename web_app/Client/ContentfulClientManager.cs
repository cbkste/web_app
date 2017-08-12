using Contentful.Core;
using Contentful.Core.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using web_app.Config;
using web_app.Helpers;

namespace web_app.Client
{

    public interface IContentfulClientManager
    {
        IContentfulClient GetClient(IOptions<ContenfulClientConfiguration> config);
    }

    public class ContentfulClientManager : IContentfulClientManager
    {
        private readonly HttpClient _httpclient;


        public ContentfulClientManager(HttpClient client)
        {
            _httpclient = client;
        }

        public IContentfulClient GetClient(IOptions<ContenfulClientConfiguration> config)
        {
            var options = new ContentfulOptions()
            {
                DeliveryApiKey = config.Value.AccessKey,
                SpaceId = config.Value.SpaceKey
            };

            var client = new ContentfulClient(_httpclient, options);

            return client;
        }
    }
}
