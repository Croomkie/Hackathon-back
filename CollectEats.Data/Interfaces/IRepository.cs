namespace Hackathon.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task SaveChanges();
        void Update(T entity);
        void Delete(T entity);
    }
}
