using System.Collections;

namespace HakunaMatata.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected List<T> _repository;

        public Repository(List<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
        }

        public T Get(int id)
        {
            return _repository.ElementAt(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _repository.GetEnumerator();
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T searchedItem)
        {
            foreach (var item in _repository)
            {
                if (item.Equals(searchedItem))
                    return _repository.IndexOf(item);
            }

            return -1;
        }
    }
}
