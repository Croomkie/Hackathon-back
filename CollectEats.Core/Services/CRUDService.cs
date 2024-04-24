using AutoMapper;
using Hackathon.Core.Interfaces;
using Hackathon.Data.Interfaces;
using System.Linq.Expressions;

namespace Hackathon.Core.Services
{
    public class CRUDService<T, TDto> : ICRUDService<TDto> where T : class where TDto : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        public CRUDService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var model = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TDto>>(model);
        }

        public async Task<TDto> GetById(int id)
        {
            var model = await _repository.GetById(id);
            return _mapper.Map<TDto>(model);
        }

        public async Task Add(TDto modelDTO)
        {
            var model = _mapper.Map<T>(modelDTO);
            await _repository.Add(model);
            await _repository.SaveChanges();
        }

        public async Task Update(int id, TDto modelDTO)
        {
            var model = await _repository.GetById(id);
            if (model != null)
            {
                _mapper.Map(modelDTO, model);
                _repository.Update(model);
                await _repository.SaveChanges();
            }
        }

        public async Task Delete(int id)
        {
            var restaurant = await _repository.GetById(id);
            if (restaurant != null)
            {
                _repository.Delete(restaurant);
                await _repository.SaveChanges();
            }
        }

        public async Task<TDto> GetByIdIncluding(Expression<Func<TDto, bool>> idPredicateDto, params Expression<Func<TDto, object>>[] includePropertiesDto)
        {
            var idPredicate = _mapper.Map<Expression<Func<T, bool>>>(idPredicateDto);
            var includeProperties = includePropertiesDto.Select(dtoExp => _mapper.Map<Expression<Func<T, object>>>(dtoExp)).ToArray();
            var modelWithInclude = await _repository.GetByIdIncluding(idPredicate, includeProperties);
            return _mapper.Map<TDto>(modelWithInclude);
        }


        public async Task<IEnumerable<TDto>> GetAllIncluding(params Expression<Func<TDto, object>>[] includePropertiesDto)
        {
            // Convertir les expressions pour les propriétés d'inclusion
            var includeProperties = includePropertiesDto.Select(dtoProp => _mapper.Map<Expression<Func<T, object>>>(dtoProp)).ToArray();
            var models = await _repository.GetAllIncluding(includeProperties);
            return models.Select(_mapper.Map<TDto>);
        }
    }
}
