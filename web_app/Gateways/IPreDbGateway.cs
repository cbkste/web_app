using System.Collections.Generic;
using System.Threading.Tasks;
using web_app.Gateways.Responses;
using web_app.ViewModels;

namespace web_app.Gateways
{
    public interface IPreDbGateway
    {
        Task<List<PreDbRssFeedItem>> GetRssFeed();
    }
}