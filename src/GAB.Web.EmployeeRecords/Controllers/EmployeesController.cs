using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Http.ApiClients;

namespace GAB.Web.EmployeeRecords.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRecordsApiClient _employeeRecordsApiClient =
                  new EmployeeRecordsApiClient(ConfigurationManager.AppSettings["EmployeeRecordsApiBaseUrl"]);

        // GET: /Employees/
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employees = await _employeeRecordsApiClient.Get();

            return View(employees);
        }

        // GET: /Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Role,Department,HourlyRate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRecordsApiClient.Create(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: /Employees/Edit/649b608e-4adc-43b9-832e-1ac581fee88a
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await _employeeRecordsApiClient.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employees/Edit/649b608e-4adc-43b9-832e-1ac581fee88a
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Role,Department,HourlyRate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRecordsApiClient.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employees/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await _employeeRecordsApiClient.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employees/Delete/649b608e-4adc-43b9-832e-1ac581fee88a
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed([Bind(Include = "Id")] string id)
        {
            await _employeeRecordsApiClient.Delete(id);
            return RedirectToAction("Index");
        }
    }
}