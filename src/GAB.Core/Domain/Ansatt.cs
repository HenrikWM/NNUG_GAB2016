using System;

namespace GAB.Core.Domain
{
    public class Ansatt : Entity
    {
        public string Navn { get; set; }
        public string Avdeling { get; set; }
        public string Rolle { get; set; }
        
        public static Ansatt Create(string navn, string avdeling, string rolle)
        {
            return new Ansatt
            {
                Navn = navn,
                Avdeling = avdeling,
                Rolle = rolle
            };
        }
    }
}
