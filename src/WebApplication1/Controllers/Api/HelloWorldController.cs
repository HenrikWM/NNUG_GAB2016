using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers.Api
{
    public class HelloWorldController : ApiController
    {
        // GET: HelloWorld
        [System.Web.Mvc.HttpGet]
        public JsonResult GetHelloWorld()
        {
            dynamic result = new
            {
                Name = "Number",
                Value = 1
            };

            return new JsonResult { Data = result, ContentType = "application/json" };
        }
    }
}