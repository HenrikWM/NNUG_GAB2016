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

        /// <summary>
        /// Creates an employee
        /// </summary>
        /// <param name="employee">An employee</param>
        /// <remarks>Creates an employee in the database</remarks>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [ResponseType(typeof(Employee))]
        public async Task<HttpResponseMessage> Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Document createdDocument = await DocumentDBRepository<Employee>.CreateItemAsync(employee);
                employee.Id = createdDocument.Id;

                return Request.CreateResponse(HttpStatusCode.Created, employee);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Updates an employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="employee">The updated employee</param>
        /// <remarks>Updates an employee in the database</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee existingEmployee = DocumentDBRepository<Employee>.GetItem(d => d.Id == employee.Id);

                if (existingEmployee == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                await DocumentDBRepository<Employee>.UpdateItemAsync(employee.Id, employee);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Deletes an employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <remarks>Deletes an employee from the database</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Employee employee = DocumentDBRepository<Employee>.GetItem(d => d.Id == id);

            if (employee == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            await DocumentDBRepository<Employee>.DeleteItemAsync(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}