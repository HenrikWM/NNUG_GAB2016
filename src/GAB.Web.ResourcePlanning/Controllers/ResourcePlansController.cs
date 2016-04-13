using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Http.ApiClients;
using GAB.Web.ResourcePlanning.Models;

namespace GAB.Web.ResourcePlanning.Controllers
{
    public class ResourcePlansController : Controller
    {
        // GET: Planning
        public async Task<ActionResult> Index()
        {

            EmployeeRecordsApiClient client = new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);
            var employees = await client.Get();
            var viewmodel = new WorkPlanViewModel();
            viewmodel.Employees = employees;
            return View(viewmodel);
        }
        

        public async Task<ActionResult> Save(WorkPlanViewModel viewmodel)
        {
            ResourcePlansApiClient client = new ResourcePlansApiClient(ConfigurationManager.AppSettings["ResourcePlansApiBaseUrl"]);

            var fromDateTime = viewmodel.StartDate - viewmodel.StartTime;
            var toDateTime = viewmodel.StartDate - viewmodel.EndTime +
                             (viewmodel.EndTime > viewmodel.StartTime ? TimeSpan.Zero : new TimeSpan(1, 0, 0, 0));

            if (viewmodel.Id == null)
            {
                await client.Create(new ResourcePlan
                {
                    Id = viewmodel.Id,
                    EmployeeId = viewmodel.EmployeeId,
                    From = fromDateTime,
                    To = toDateTime
                });
            }
            else
            {
                await client.Create(new ResourcePlan
                {
                    Id = viewmodel.Id,
                    EmployeeId = viewmodel.EmployeeId,
                    From = fromDateTime,
                    To = toDateTime
                });
            }

            return RedirectToAction("Index", "ResourcePlans");

        }
    }
}