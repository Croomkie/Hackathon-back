namespace Hackathon.Core.Interfaces
{
    public interface ICRUDService<TDto>
    {
        Task<IEnumerable<TDto>> GetAll();

        Task<TDto> GetById(Guid id);

        Task Add(TDto modelDTO);

        Task Update(Guid id, TDto modelDTO);

        Task Delete(Guid id);
    }
}
