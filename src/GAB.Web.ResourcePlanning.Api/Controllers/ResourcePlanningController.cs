using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;
using GAB.Http.ApiClients;
using Microsoft.Azure.Documents;

namespace GAB.Web.ResourcePlanning.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using GAB.Core.Domain.ResourcePlanning;
    using GAB.Web.ResourcePlanning.Api.Models;

    public class ResourcePlanningController : ApiController
    {
        private readonly EmployeeRecordsApiClient _employeeRecordsApiClient =
            new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);

        /// <summary>
        /// Creates a resource plan for an employee
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <param name="planForEmployeeRequest">Request object with start and end time for plan</param>
        /// <remarks>Creates a resource plan for the employee</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response> 
        [HttpPost]
        [ResponseType(typeof(ResourcePlan))]
        public async Task<HttpResponseMessage> PlanForEmployee(
            [FromUri] string employeeId, 
            [FromBody] PlanForEmployeeRequest planForEmployeeRequest)
        {
            if (string.IsNullOrEmpty(employeeId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Employee employee = await _employeeRecordsApiClient.GetById(employeeId);

            if (employee == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // Create resource plan for employee
            ResourcePlan resourcePlanForEmployee = ResourcePlan.Create(
                employee.Id,
                planForEmployeeRequest.PlanStartsAt,
                planForEmployeeRequest.PlanEndsAt);

            IEnumerable<ResourcePlan> existingResourcePlans = DocumentDBRepository<ResourcePlan>.GetAllItems();

            // Ensure no overlapping of existing plans
            if (ResourcePlanOverlapping.HasOverlapping(resourcePlanForEmployee, existingResourcePlans))
            {
                return Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    string.Format(
                        "New resource plan starting on {0} would overlap with existing resource plan for employee {1}",
                        planForEmployeeRequest.PlanStartsAt,
                        employeeId));
            }

            Document createdDocument = await DocumentDBRepository<ResourcePlan>.CreateItemAsync(resourcePlanForEmployee);
            resourcePlanForEmployee.Id = createdDocument.Id;

            // TODO: Call calculations API with ResourcePlan, store returned report.

            return Request.CreateResponse(HttpStatusCode.Created, resourcePlanForEmployee);
        }

        /// <summary>
        /// Gets all resource plans
        /// </summary>
        /// <remarks>Gets all resource plans from the database</remarks>
        /// <response code="404">Not found</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ResourcePlan>))]
        public HttpResponseMessage Get()
        {
            IEnumerable<ResourcePlan> resourcePlans = DocumentDBRepository<ResourcePlan>.GetAllItems();

            if (resourcePlans == null || !resourcePlans.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, resourcePlans);
        }

        /// <summary>
        /// Gets a resource plan
        /// </summary>
        /// <param name="id">ResourcePlan id</param>
        /// <remarks>Gets a resource plan from the database</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>        
        [HttpGet]
        [ResponseType(typeof(ResourcePlan))]
        public HttpResponseMessage Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            ResourcePlan resourcePlan = DocumentDBRepository<ResourcePlan>.GetItem(d => d.Id == id);

            if (resourcePlan == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, resourcePlan);
        }
    }
}
