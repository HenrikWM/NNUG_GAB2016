using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;
using Microsoft.Azure.Documents;

namespace GAB.Web.Reports.Api.Controllers
{
    public class ReportsController : ApiController
    {
        /// <summary>
        /// Gets all reports
        /// </summary>
        /// <remarks>Gets all reports from the database</remarks>
        /// <response code="404">Not found</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Report>))]
        public HttpResponseMessage Get()
        {
            IEnumerable<Report> reports = DocumentDBRepository<Report>.GetAllItems();

            if (reports == null || !reports.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, reports);
        }

        /// <summary>
        /// Creates a report
        /// </summary>
        /// <param name="report">A report</param>
        /// <remarks>Creates a report in the database</remarks>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [ResponseType(typeof(Report))]
        public async Task<HttpResponseMessage> Create([FromBody] Report report)
        {
            if (ModelState.IsValid)
            {
                Document createdDocument = await DocumentDBRepository<Report>.CreateItemAsync(report);
                report.Id = createdDocument.Id;

                return Request.CreateResponse(HttpStatusCode.Created, report);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
