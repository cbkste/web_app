using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace web_app.Helpers
{
    public class Response<T> where T : class, new()
    {
        public HttpStatusCode Status { get; set; }
        public string ErrorMsg { get; set; }
        public T ResponseContent { get; set; }

        public static Response<T> Get(string requestUrl, string serializedContent, HttpStatusCode httpStatus)
        {
            if (httpStatus.IsServerError())
            {

                return new Response<T>
                {
                    ResponseContent = Activator.CreateInstance<T>(),
                    Status = httpStatus
                };
            }


            return new Response<T>
            {
                ResponseContent = DeserializeObject(serializedContent),
                Status = httpStatus
            };
        }

        private static T DeserializeObject(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }


    }
}