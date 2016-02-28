using GAB.Core.Repositories;
using System.Collections.Generic;
using System;
using GAB.Core.Domain;
using System.Linq;

namespace GAB.Core.Repositories.InMemory
{
    public class InMemoryRolleRepository : IRepository<Rolle>
    {
        private List<Rolle> _repository = new List<Rolle>();

        public InMemoryRolleRepository()
        {
            Seed();
        }

        private void Seed()
        {
            _repository = new List<Rolle>
            {
                Rolle.Create("Vognfører"),
                Rolle.Create("Trafikkstyrer"),
                Rolle.Create("Vedlikehold")
            };
        }

        public IEnumerable<Rolle> GetAll()
        {
            return _repository.ToList();
        }
    }
}
