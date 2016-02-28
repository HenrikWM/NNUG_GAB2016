using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAB.Core.Domain
{
    public class Rolle : Entity
    {
        public string Navn { get; set; }

        public static Rolle Create(string navn)
        {
            return new Rolle
            {
                Navn = navn
            };
        }
    }
}
