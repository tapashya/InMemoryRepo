using System.Collections.Generic;

namespace Interview
{
    public interface IRepository<T, I> where T : IStoreable<I>
    {
        IEnumerable<T> GetAll();
        T Get(I id);
        void Delete(I id);
        void Save(T item);
    }
}
