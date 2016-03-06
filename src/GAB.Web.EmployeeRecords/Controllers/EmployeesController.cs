using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAB.Core.Domain;
using GAB.Core.Repositories.DocumentDB;

namespace GAB.Web.EmployeeRecords.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: /Employees/
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = DocumentDBRepository<Employee>.GetAllItems();

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
                await DocumentDBRepository<Employee>.CreateItemAsync(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: /Employees/Edit/649b608e-4adc-43b9-832e-1ac581fee88a
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = DocumentDBRepository<Employee>.GetItem(d => d.Id == id);
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
                await DocumentDBRepository<Employee>.UpdateItemAsync(employee.Id, employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = DocumentDBRepository<Employee>.GetItem(d => d.Id == id);
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
            await DocumentDBRepository<Employee>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}