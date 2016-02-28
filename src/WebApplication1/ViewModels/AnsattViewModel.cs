using GAB.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAB.Web.Personalregister.ViewModels
{
    public class AnsattViewModel
    {
        public string Id { get; internal set; }

        public string Navn { get; internal set; }
        public RolleViewModel Rolle { get; internal set; }
        public string Avdeling { get; internal set; }

        internal static AnsattViewModel MapFromModel(Ansatt ansatt)
        {
            return new AnsattViewModel
            {
                Id = ansatt.Id.ToString("N"),
                Navn = ansatt.Navn,
                Rolle = RolleViewModel.MapFromModel(ansatt.Rolle),
                Avdeling = ansatt.Avdeling
            };
        }

        internal static IEnumerable<AnsattViewModel> MapFromModel(IEnumerable<Ansatt> ansatte)
        {
            List<AnsattViewModel> model = new List<AnsattViewModel>();

            foreach (Ansatt ansatt in ansatte)
            {
                model.Add(MapFromModel(ansatt));
            }

            return model;
        }

        internal static Ansatt MapFromViewModel(AnsattViewModel model)
        {
            return new Ansatt
            {
                Navn = model.Navn,
                Rolle = RolleViewModel.MapFromViewModel(model.Rolle),
                Avdeling = model.Avdeling
            };
        }
    }
}