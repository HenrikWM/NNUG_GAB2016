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
        
        public void Add(Rolle entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Rolle> GetAll()
        {
            return _repository.ToList();
        }

        public Rolle Find(Guid id)
        {
            return _repository.Find(o => o.Id == id);
        }

        public void Update(Rolle rolle)
        {
            Rolle existing = Find(rolle.Id);

            _repository.Remove(existing);

            _repository.Add(rolle);
        }

        public void Delete(Guid id)
        {
            Rolle rolle = Find(id);

            if (rolle != null)
                _repository.Remove(rolle);
        }
    }
}
