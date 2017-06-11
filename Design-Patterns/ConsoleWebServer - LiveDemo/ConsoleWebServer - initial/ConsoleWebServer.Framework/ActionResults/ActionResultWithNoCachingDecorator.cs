using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.ActionResults;

namespace ConsoleWebServer.Application.Controllers
{
    public class ActionResultWithNoCachingDecorator : ActionResultDecorator
    {
        public ActionResultWithNoCachingDecorator(IActionResult actionResult)
            : base(actionResult)
        {
        }

        protected override void UpdateResponse(HttpResponse response)
        {
            response.AddHeader("Cache-Control", "private, max-age=0, no-cache");
        }
    }
}