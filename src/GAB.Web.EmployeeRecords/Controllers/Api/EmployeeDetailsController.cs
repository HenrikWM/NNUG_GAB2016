using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;

namespace GAB.Web.EmployeeRecords.Controllers.Api
{
    public class EmployeeDetailsController : ApiController
    {
        // GET api/employeedetails/get
        [HttpGet]
        public HttpResponseMessage Get()
        {
            IEnumerable<Employee> ansatte = DocumentDBRepository<Employee>.GetAllItems();

            if (ansatte == null || !ansatte.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, ansatte);
        }

        // GET api/employeedetails/get/649b608e-4adc-43b9-832e-1ac581fee88a
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Employee employee = DocumentDBRepository<Employee>.GetItem(d => d.Id == id);

            if (employee == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }    
    }
}