namespace Hackathon.Core.Interfaces
{
    public interface ICRUDService<TDto>
    {
        Task<IEnumerable<TDto>> GetAll();

        Task<TDto> GetById(int id);

        Task Add(TDto modelDTO);

        Task Update(int id, TDto modelDTO);

        Task Delete(int id);
    }
}
