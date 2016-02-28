using System;

namespace GAB.Core.Domain
{
    public class Ansatt : Entity
    {
        public string Navn { get; set; }
        public string Avdeling { get; set; }
        public Rolle? Rolle { get; set; }
        
        public static Ansatt Create(string navn, string avdeling, Rolle rolle)
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
