using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using web_app.Config;
using web_app.Gateways;
using web_app.Helpers;
using web_app.Http;
using web_app.ILolEsportsFactory;
using web_app.LolEsportsModels;
using web_app.Model;

namespace web_app.Repository
{
    public class LolEsportsGateway : ILolEsportsGateway
    {
        private readonly ILolEsportsFactory<LolEsportsTeam, Team> _teamFactory;
        private readonly IOptions<LolEsportsApiConfiguration> _lolEsportsApiConfig;
        private readonly IHttpClientWrap _httpClientWrap;

        public LolEsportsGateway(IOptions<LolEsportsApiConfiguration> lolEsportsApiConfig, IHttpClientWrap httpClientWrap, ILolEsportsFactory<LolEsportsTeam, Team> teamFactory)
        {
            _teamFactory = teamFactory;
            _lolEsportsApiConfig = lolEsportsApiConfig;
            _httpClientWrap = httpClientWrap;
        }

        public async Task<HttpResponse> Get()
        {
            var tournamentGuid = "3496c233-d7b5-11e6-84c1-06bf49dcca99";
            var teamSlug = "fnatic";
            var teamUrl = string.Format(_lolEsportsApiConfig.Value.TeamInfomation, teamSlug, tournamentGuid);
            var url = $"{_lolEsportsApiConfig.Value.BaseUrlv1}{teamUrl}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var result = await _httpClientWrap.DoRequest<LolEsportsTeam>(request);

            return result == null
                ? HttpResponse.Failure(HttpStatusCode.NotFound, $"No content found")
                : HttpResponse.Successful(_teamFactory.ToModel(result.ResponseContent));
        }
        
    }
}
