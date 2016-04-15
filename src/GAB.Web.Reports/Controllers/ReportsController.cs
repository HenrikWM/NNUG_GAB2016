using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;

namespace GAB.Web.Reports.Controllers
{
    using System.Linq;

    public class ReportsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<Report> reports = Enumerable.Empty<Report>(); // TODO: Implement an integration to ReportsApi and Get

            return View("Index", reports.OrderByDescending(o => o.Created));
        }
    }
}