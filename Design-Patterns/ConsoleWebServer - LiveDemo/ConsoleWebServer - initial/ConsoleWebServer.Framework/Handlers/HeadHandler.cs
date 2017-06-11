using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public class HeadHandler : Handler
    {
        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Method.ToLower() == "head";
        }

        protected override HttpResponse Handle(IHttpRequest request)
        {
            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Empty);
        }
    }
}
