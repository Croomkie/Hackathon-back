using System.Linq.Expressions;

namespace Hackathon.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task SaveChanges();
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}
