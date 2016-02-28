using GAB.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAB.Core.Repositories.InMemory
{
    public class InMemoryAnsattRepository : IRepository<Ansatt>
    {
        private List<Ansatt> _repository = new List<Ansatt>();
        
        public void Add(Ansatt entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Ansatt> GetAll()
        {
            return _repository.ToList();
        }
    }
}
