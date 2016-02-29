using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAB.Web.Personalregister.Controllers.Api
{
    using System.Collections.Generic;
    using System.Linq;

    using GAB.Core.Domain;
    using GAB.Core.Repositories.DocumentDB;

    public class PersoninfoController : ApiController
    {
        // GET api/personinfo/hent
        [HttpGet]
        public HttpResponseMessage HentPersoninfo()
        {
            IEnumerable<Ansatt> ansatte = DocumentDBRepository<Ansatt>.GetAllItems();

            if (ansatte == null || !ansatte.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, ansatte);
        }

        // GET api/personinfo/hentpersoninfo/649b608e-4adc-43b9-832e-1ac581fee88a
        [HttpGet]
        public HttpResponseMessage HentPersoninfo(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Ansatt ansatt = DocumentDBRepository<Ansatt>.GetItem(d => d.Id == id);

            if (ansatt == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, ansatt);
        }    
    }
}