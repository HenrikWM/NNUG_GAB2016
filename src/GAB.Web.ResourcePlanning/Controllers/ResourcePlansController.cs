using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Http.ApiClients;
using GAB.Web.ResourcePlanning.Models;

namespace GAB.Web.ResourcePlanning.Controllers
{
    public class ResourcePlansController : Controller
    {
        readonly ResourcePlansApiClient _resourcePlansApiClient = new ResourcePlansApiClient(ConfigurationManager.AppSettings["ResourcePlansApiBaseUrl"]);
        readonly EmployeeRecordsApiClient _employeeRecordsApiClient = new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);
        readonly CalculationsApiClient _calculationsApiClient = new CalculationsApiClient(ConfigurationManager.AppSettings["CalculationsApiBaseUrl"]);
        readonly ReportsApiClient _reportsApiClient = new ReportsApiClient(ConfigurationManager.AppSettings["ReportsApiBaseUrl"]);
        
        // GET: Planning
        public async Task<ActionResult> Index()
        {
            var employees = await _employeeRecordsApiClient.Get();
            var resourcePlans = await _resourcePlansApiClient.Get();
            
            //TODO: Try adding a link to a report once one has been generated for a resource plan. Display a Calculate-link if one doesn't exist

            var resourcePlanViewModels = CreateResourcePlanViewModels(resourcePlans, employees);

            var viewmodel = new WorkPlanViewModel
            {
                Employees = employees,
                ResourcePlans = resourcePlanViewModels.OrderByDescending(o => o.From)
            };

            return View(viewmodel);
        }

        public async Task<ActionResult> Save(WorkPlanViewModel viewmodel)
        {
            var fromDateTime = viewmodel.StartDate + viewmodel.StartTime;
            var toDateTime = viewmodel.StartDate + viewmodel.EndTime +
                             (viewmodel.EndTime > viewmodel.StartTime ? TimeSpan.Zero : new TimeSpan(1, 0, 0, 0));

            await _resourcePlansApiClient.Create(new ResourcePlan
            {
                EmployeeId = viewmodel.EmployeeId,
                From = fromDateTime,
                To = toDateTime
            });

            return RedirectToAction("Index", "ResourcePlans");
        }
        
        // GET: 
        public async Task<ActionResult> CalculateCapacity(string id)
        {
            var resourcePlan = await _resourcePlansApiClient.GetById(id);
            
            Report report = await _calculationsApiClient.CalculateCapacity(resourcePlan);

            await _reportsApiClient.Create(report);

            return RedirectToAction("Index");
        }

        private List<ResourcePlanViewModel> CreateResourcePlanViewModels(
            IEnumerable<ResourcePlan> resourcePlans, 
            IEnumerable<Employee> employees)
        {
            List<ResourcePlanViewModel> resourcePlanViewModels = new List<ResourcePlanViewModel>();
            foreach (ResourcePlan resourcePlan in resourcePlans)
            {
                ResourcePlanViewModel resourcePlanViewModel = new ResourcePlanViewModel
                {
                    Id = resourcePlan.Id,
                    From = resourcePlan.From,
                    To = resourcePlan.To,
                    EmployeeName = employees.First(o => o.Id == resourcePlan.EmployeeId).Name
                };

                resourcePlanViewModels.Add(resourcePlanViewModel);
            }
            return resourcePlanViewModels;
        }
    }
}