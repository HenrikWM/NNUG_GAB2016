using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Http.ApiClients;

namespace GAB.Web.Reports.Controllers
{
    using System.Linq;

    public class ReportsController : Controller
    {
        private readonly ReportsApiClient _reportsApiClient =
               new ReportsApiClient(ConfigurationManager.AppSettings["ReportsApiBaseUrl"]);

        public async Task<ActionResult> Index()
        {
            IEnumerable<Report> reports = await _reportsApiClient.Get(); 

            return View("Index", reports.OrderByDescending(o => o.EmployeeName));
        }

        public ActionResult Persons()
        {
            return View();
        }

        public ActionResult WorkHours()
        {
            return View();
        }

        public ActionResult Capacity()
        {
            return View();
        }

        public ActionResult Costs()
        {
            return View();
        }
    }
}