using GAB.Core.Domain;
using GAB.Core.Repositories;
using GAB.Core.Repositories.InMemory;
using GAB.Web.Personalregister.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAB.Web.Personalregister.Controllers
{
    public class RolleController : Controller
    {
        private IRepository<Rolle> _repository;

        public RolleController()
        {
            _repository = new InMemoryRolleRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Rolle> rolle = _repository.GetAll();

            IEnumerable<RolleViewModel> model = RolleViewModel.MapFromModel(rolle);

            return View("Index", model);
        }

        public ActionResult Create(RolleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid model");

                return View("Index", model);
            }

            Rolle rolle = RolleViewModel.MapFromViewModel(model);

            _repository.Add(rolle);

            return RedirectToAction("Index");
        }
    }
}