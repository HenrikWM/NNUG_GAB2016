using GAB.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAB.Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        T Find(Guid id);

        void Update(T entity);

        void Delete(Guid id);
    }
}
