using System.Net.Http;
using System.Threading.Tasks;

namespace web_app.Helpers
{
    public interface IHttpClientWrap
    {
        Task<Response<T>> DoRequest<T>(string url) where T : class, new();
        Task<Response<T>> DoRequest<T>(HttpRequestMessage message) where T : class, new();
    }
}