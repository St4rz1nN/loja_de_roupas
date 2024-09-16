namespace LojaRoupasApi.Domain.Interfaces.Base
{
    public interface IBaseService<TDto, T> where TDto : class where T : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto> GetByIdAsync(Guid id);

        Task<Guid> AddAsync(TDto entity);

        Task UpdateAsync(TDto entity);

        Task DeleteAsync(Guid id);
    }
}
