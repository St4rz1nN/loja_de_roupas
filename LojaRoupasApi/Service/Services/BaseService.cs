using AutoMapper;
using LojaRoupasApi.Domain.Interfaces.Base;

namespace LojaRoupasApi.Service.Services
{
    public class BaseService<TDto, T> : IBaseService<TDto, T> where TDto : class where T : class
    {
        private readonly IBaseRepository<T> _repositoryBase;
        private IMapper _mapper;
        public BaseService(IBaseRepository<T> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        private TDto ConvertToDto(T entity)
        {
            return _mapper.Map<TDto>(entity);
        }

        private T ConvertFromDto(TDto entityDto)
        {
            return _mapper.Map<T>(entityDto);
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repositoryBase.GetAllAsync();
            var entitiesDto = entities.Select(e => ConvertToDto(e));
            return entitiesDto;
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _repositoryBase.GetByIdAsync(id);
            var entityDto = ConvertToDto(entity);
            return entityDto;
        }

        public async Task AddAsync(TDto entityDto)
        {
            var entity = ConvertFromDto(entityDto);
            await _repositoryBase.AddAsync(entity);
        }

        public async Task UpdateAsync(TDto entityDto)
        {
            var entity = ConvertFromDto(entityDto);
            await _repositoryBase.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repositoryBase.DeleteAsync(id);
        }
    }
}
