using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;
using GAB.Web.ResourcePlanning.Api.Clients;
using Microsoft.Azure.Documents;

namespace GAB.Web.ResourcePlanning.Api.Controllers
{
    public class ResourcePlanningController : ApiController
    {
        private readonly EmployeeRecordsApiClient _employeeRecordsApiClient =
            new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);

        /// <summary>
        /// Creates a resource plan for an employee
        /// </summary>
        /// <param name="employeeId">Employee id</param>
        /// <remarks>Creates a resource plan for the employee</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response> 
        [HttpPost]
        [ResponseType(typeof(ResourcePlan))]
        public async Task<HttpResponseMessage> PlanForEmployee(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Employee employee = await _employeeRecordsApiClient.GetById(employeeId);

            if (employee == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // Create resource plan for employee for today
            ResourcePlan resourcePlanForEmployee = ResourcePlan.CreateForToday(employee);
            
            Document createdDocument = await DocumentDBRepository<ResourcePlan>.CreateItemAsync(resourcePlanForEmployee);
            resourcePlanForEmployee.Id = createdDocument.Id;

            return Request.CreateResponse(HttpStatusCode.Created, resourcePlanForEmployee);
        }
    }
}
