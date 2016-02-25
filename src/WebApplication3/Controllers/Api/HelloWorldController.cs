using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers.Api
{
    public class HelloWorldController : ApiController
    {
        // POST: HelloWorld
        [HttpPost]
        public HttpResponseMessage Post([FromBody]int result)
        {
            Trace.WriteLine($"[HelloWorldController.Index] - called with: {result}");

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}