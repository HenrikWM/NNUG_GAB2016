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
    public class PlanningController : Controller
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
            PlanningApiClient client = new PlanningApiClient(ConfigurationManager.AppSettings["PlanningApiBaseUrl"]);
            if (viewmodel.Id == null)
            {
                await client.Create(new ResourcePlan
                {
                    Id = viewmodel.Id,
                    EmployeeId = viewmodel.EmployeeId,
                    From = viewmodel.StartTime,
                    To = viewmodel.EndTime

                });
            }
            else
            {
                await client.Create(new ResourcePlan
                {
                    Id = viewmodel.Id,
                    EmployeeId = viewmodel.EmployeeId,
                    From = viewmodel.StartTime,
                    To = viewmodel.EndTime

                });
            }

            return RedirectToAction("Index", "Planning");

        }
    }
}