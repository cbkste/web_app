using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace web_app.Helpers
{
    public static class HttpStatusExtensions
    {
        public static bool IsServerError(this HttpStatusCode code)
        {
            // Anything of status 400 or beyond
            return code >= HttpStatusCode.BadRequest;
        }
    }
}
