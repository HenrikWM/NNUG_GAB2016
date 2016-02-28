using GAB.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAB.Web.Personalregister.ViewModels
{
    public class RolleViewModel
    {
        public string Id { get; internal set; }

        public string Navn { get; internal set; }

        internal static RolleViewModel MapFromModel(Rolle rolle)
        {
            return new RolleViewModel
            {
                Id = rolle.Id.ToString("N"),
                Navn = rolle.Navn
            };
        }

        internal static IEnumerable<RolleViewModel> MapFromModel(IEnumerable<Rolle> roller)
        {
            List<RolleViewModel> model = new List<RolleViewModel>();

            foreach (Rolle rolle in roller)
            {
                model.Add(MapFromModel(rolle));
            }

            return model;
        }

        internal static Rolle MapFromViewModel(RolleViewModel rolle)
        {
            return new Rolle
            {
                Navn = rolle.Navn
            };
        }
    }
}