using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private List<T> repositoryObjects;

        public Repository()
        {
            repositoryObjects = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return repositoryObjects;
        }

        public T Get(I id)
        {
            return repositoryObjects.FirstOrDefault(e=>e.Id.Equals(id));
        }

        public void Delete(I id)
        {
            repositoryObjects.Remove(repositoryObjects.First(obj => obj.Id.Equals(id)));
        }

        public void Save(T item)
        {
            repositoryObjects.Add(item);
        }
    }
}
