using System.Net.Http;

namespace web_app.Gateways
{
    internal class JsonHttpRequestMessage
    {
        private string url;
        private HttpMethod httpMethod;
        private object payload;

        public JsonHttpRequestMessage(string url, HttpMethod httpMethod, object payload)
        {
            this.url = url;
            this.httpMethod = httpMethod;
            this.payload = payload;
        }
    }
}