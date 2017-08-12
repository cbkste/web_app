using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Http;

namespace web_app
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {
        }

        // TODO: Possibly not the most elegant way of doing this.
        public async Task<IActionResult> Get(Func<Task<HttpResponse>> doGet)
        {
            HttpResponse response;
            try
            {
                response = await doGet();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

            return response.CreateResult();
        }
    }
}
