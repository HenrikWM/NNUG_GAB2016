using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;

namespace GAB.Web.EmployeeRecords.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: /Employees/
        public async Task<ActionResult> Index()
        {
            IEnumerable<Employee> employees = null; //TODO: Implement an integration to EmployeeRecordsApi and GetAll

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
            if (ModelState.IsValid == false)
            {
                return View(employee);
            }

            //TODO: Implement an integration to EmployeeRecordsApi and Create

            return RedirectToAction("Index");
        }

        // GET: /Employees/Edit/649b608e-4adc-43b9-832e-1ac581fee88a
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = null; //TODO: Implement an integration to EmployeeRecordsApi and GetById

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
            if (ModelState.IsValid == false)
            {
                return View(employee);
            }

            //TODO: Implement an integration to EmployeeRecordsApi and Update

            return RedirectToAction("Index");
        }

        // GET: /Employees/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = null; //TODO: Implement an integration to EmployeeRecordsApi and GetById

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
            //TODO: Implement an integration to EmployeeRecordsApi and Delete

            return RedirectToAction("Index");
        }
    }
}