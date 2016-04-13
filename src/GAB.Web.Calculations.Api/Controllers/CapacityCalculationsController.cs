using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GAB.Core.Domain;
using GAB.Http.ApiClients;

namespace GAB.Web.Calculations.Api.Controllers
{
    using GAB.Core.Domain.ResourcePlanning;

    public class CapacityCalculationsController : ApiController
    {
        private readonly EmployeeRecordsApiClient _employeeRecordsApiClient =
                    new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);

        /// <summary>
        /// Calculates capacity and returns a report
        /// </summary>
        /// <param name="resourcePlan">Resource plan</param>
        /// <remarks>Calculates capacity based on a provided resource plan and returns a report</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response> 
        [HttpPost]
        [ResponseType(typeof(Report))]
        public async Task<HttpResponseMessage> CalculateCapacityForResourcePlan([FromBody] ResourcePlan resourcePlan)
        {
            if (ModelState.IsValid == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Employee employee = await _employeeRecordsApiClient.GetById(resourcePlan.EmployeeId);

            if (employee == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
                
            double utilizationForEmployeeInPercent = CapacityCalculator.CalculateUtilizationForEmployee(resourcePlan);

            double utilizationForDepartmentInPercent = CapacityCalculator.CalculateUtilizationForDepartment(resourcePlan);
        
            Report report = new Report {
                EmployeeName = employee.Name,
                EmployeeDepartment = employee.Department,
                UtilizationForEmployeeInPercent = utilizationForEmployeeInPercent,
                UtilizationForDepartmentInPercent = utilizationForDepartmentInPercent
            };

            return Request.CreateResponse(HttpStatusCode.OK, report);
        }
    }
}