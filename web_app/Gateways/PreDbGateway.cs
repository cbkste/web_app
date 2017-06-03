using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using web_app.Gateways.Responses;
using web_app.ViewModels;

namespace web_app.Gateways
{
    public class PreDbGateway : IPreDbGateway
    {
        public async Task<List<PreDbRssFeedItem>> GetRssFeed()
        {
            var feed = new List<PreDbRssFeedItem>();
            var feedUrl = "https://predb.me/?cats=movies-hd&rss=1";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.BaseAddress = new Uri(feedUrl);
                var responseMessage = await client.GetAsync(feedUrl);
                var responseString = await responseMessage.Content.ReadAsStringAsync();

                //extract feed items
                XDocument doc = XDocument.Parse(responseString);
                var feedItems = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                    select new PreDbRssFeedItem
                    {
                        Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                        Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                    };
                feed = feedItems.ToList();
            }
            return feed;
        }
    }
}
