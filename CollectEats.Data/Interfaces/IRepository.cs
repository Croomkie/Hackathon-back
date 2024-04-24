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
        Task<T?> GetByIdIncluding(Expression<Func<T, bool>> idPredicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}
