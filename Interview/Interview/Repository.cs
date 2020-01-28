using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    // In memory implementation of IRepository<T, I> 

    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private List<T> _repositoryObjects;

        public Repository()
        {
            _repositoryObjects = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _repositoryObjects;
        }

        public T Get(I id)
        {
            return _repositoryObjects.FirstOrDefault(e=>e.Id.Equals(id));
        }

        public void Delete(I id)
        {
            foreach (var n in _repositoryObjects.Where(obj => obj.Id.Equals(id)).ToArray())
            {
                _repositoryObjects.Remove(n);
            }
        }

        public void Save(T item)
        {
            if (_repositoryObjects.FirstOrDefault(obj => obj.Id.Equals(item.Id)) != null)
            {
                Delete(item.Id); //if we don't want duplicates
            }
            _repositoryObjects.Add(item);
        }
    }
}
