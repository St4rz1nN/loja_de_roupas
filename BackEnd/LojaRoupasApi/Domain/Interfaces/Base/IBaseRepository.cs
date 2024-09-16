namespace LojaRoupasApi.Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<Guid> AddAsync(T entity);
        Task DeleteAsync(Guid id);

        Task UpdateAsync(T entity);

    }
}
