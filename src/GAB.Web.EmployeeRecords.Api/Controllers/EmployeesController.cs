using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;

namespace GAB.Web.EmployeeRecords.Api.Controllers
{
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <remarks>Gets all employees from the database</remarks>
        /// <response code="404">Not found</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Employee>))]
        public HttpResponseMessage Get()
        {
            IEnumerable<Employee> employees = DocumentDBRepository<Employee>.GetAllItems();

            if (employees == null || !employees.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        /// <summary>
        /// Gets an employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <remarks>Gets an employee from the database</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>        
        [HttpGet]
        [ResponseType(typeof(Employee))]
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