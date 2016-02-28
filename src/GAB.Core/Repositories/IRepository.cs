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
        IEnumerable<T> GetAll();
    }
}
