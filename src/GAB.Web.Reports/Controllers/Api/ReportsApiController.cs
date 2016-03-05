using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;

namespace GAB.Web.Reports.Controllers.Api
{
    public class ReportsApiController : ApiController
    {
        //// GET api/reports/get
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    IEnumerable<Report> reports = DocumentDBRepository<Report>.GetAllItems();

        //    if (reports == null || !reports.Any())
        //        return Request.CreateResponse(HttpStatusCode.NotFound);

        //    return Request.CreateResponse(HttpStatusCode.OK, reports);
        //}

        //// GET api/reports/get/649b608e-4adc-43b9-832e-1ac581fee88a
        //[HttpGet]
        //public HttpResponseMessage Get(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);

        //    Report report = DocumentDBRepository<Report>.GetItem(d => d.Id == id);

        //    if (report == null)
        //        return Request.CreateResponse(HttpStatusCode.NotFound);

        //    return Request.CreateResponse(HttpStatusCode.OK, report);
        //}
    }
}
