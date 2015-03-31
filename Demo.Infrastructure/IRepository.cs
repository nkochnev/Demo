using System.Linq;

namespace Demo.Infrastructure
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository<T> where T : class 
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}