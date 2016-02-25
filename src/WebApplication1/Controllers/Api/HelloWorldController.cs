using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.Api
{
    public class HelloWorldController : ApiController
    {
        // GET: HelloWorld
        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get()
        {
            HelloWorldNumber number = new HelloWorldNumber { Number = 1 };

            return Request.CreateResponse(HttpStatusCode.OK, number);
        }       
    }

    public class HelloWorldNumber
    {
        public int Number { get; set; }
    }
}