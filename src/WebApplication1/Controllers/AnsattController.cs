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
    public class AnsattController : Controller
    {
        private IRepository<Ansatt> _repository;

        public AnsattController()
        {
            _repository = new InMemoryAnsattRepository();
        }
                
        public ActionResult Index()
        {
            IEnumerable<Ansatt> ansatte = _repository.GetAll();

            IEnumerable<AnsattViewModel> model = AnsattViewModel.MapFromModel(ansatte);

            return View("Index", model);
        }

        public ActionResult Create(AnsattViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Invalid model");

                return View("Index", model);
            }

            Ansatt ansatt = AnsattViewModel.MapFromViewModel(model);

            _repository.Add(ansatt);

            return RedirectToAction("Index");
        }
    }
}