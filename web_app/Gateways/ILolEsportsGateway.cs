using System.Threading.Tasks;
using web_app.Http;

namespace web_app.Gateways
{
    public interface ILolEsportsGateway
    {
        Task<HttpResponse> Get();
    }
}
