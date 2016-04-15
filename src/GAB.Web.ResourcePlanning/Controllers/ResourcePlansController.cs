using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Web.ResourcePlanning.Models;

namespace GAB.Web.ResourcePlanning.Controllers
{
    public class ResourcePlansController : Controller
    {
        // GET: Planning
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employees = Enumerable.Empty<Employee>(); //TODO: Implement an integration to EmployeeRecordsApi and Get
            IEnumerable<ResourcePlan> resourcePlans = Enumerable.Empty<ResourcePlan>(); //TODO: Implement an integration to ResourcePlanningApi and Get

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

            ResourcePlan resourcePlan = new ResourcePlan
            {
                EmployeeId = viewmodel.EmployeeId,
                From = fromDateTime,
                To = toDateTime
            };

            //TODO: Implement an integration to ResourcePlanningApi and Create

            return RedirectToAction("Index", "ResourcePlans");
        }
        
        // GET: 
        public async Task<ActionResult> CalculateCapacity(string id)
        {
            ResourcePlan resourcePlan = null; //TODO: Implement an integration to ResourcePlanningApi and GetById

            Report report = null; //TODO: Implement an integration to CapacityCalculationsApi and CalculateCapacityForResourcePlan

            // TODO: Implement an integration to ReportsApi and Create

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