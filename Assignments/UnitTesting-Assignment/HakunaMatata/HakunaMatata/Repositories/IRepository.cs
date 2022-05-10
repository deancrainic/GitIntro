namespace HakunaMatata.Repositories
{
    public interface IRepository<T> : IEnumerable<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
