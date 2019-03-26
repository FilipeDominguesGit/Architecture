using System.Collections.Generic;

namespace Onion.Core.Domain.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Save(T entity);
    }
}
