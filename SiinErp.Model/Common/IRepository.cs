using System.Collections.Generic;

namespace SiinErp.Model.Common
{
    public interface IRepository<K, T>
    {
        void Create(K id, T entity);
        T Read(K id);
        List<T> ReadAll();
        void Update(K id, T entity);
        void Delete(K id);
    }
}