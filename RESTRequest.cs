using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordAPI
{
    internal class RESTRequest
    {
        internal RequestType requestType;
        internal RouteParams route;
        internal byte[] content;
        internal string mediaType;
        internal TaskCompletionSource<HttpResponseMessage> taskSource;

        internal RESTRequest(RequestType requestType, RouteParams route, byte[] content = null, string mediaType = "application/json")
        {
            this.requestType = requestType;
            this.route = route;
            this.content = content;
            this.mediaType = mediaType;
        }
    }
}
