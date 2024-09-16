using ContextLojaRoupas = LojaRoupasApi.Data.Context.ConnectionContext;
using LojaRoupasApi.Domain.Interfaces.Base;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LojaRoupasApi.Domain.Entities.Base;

namespace LojaRoupasApi.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ContextLojaRoupas _context;
        public BaseRepository(ContextLojaRoupas context) { 
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar a Entidade {typeof(T).Name}: {ex}");

                throw;
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entities = await _context.Set<T>().FindAsync(id);
                return entities;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao puxar por ID a entidade {typeof(T).Name}: {ex}");

                throw;
            }
        }

        public async Task<Guid> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                var idProperty = typeof(T).GetProperty("Id");

                if (idProperty == null)
                {
                    throw new InvalidOperationException("A entidade não possui uma propriedade Id.");
                }

                return (Guid)idProperty.GetValue(entity);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar entidade {typeof(T).Name}: {ex}");

                throw;
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                _context.Set<T>().Remove(await _context.Set<T>().FindAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar a Entidade {typeof(T).Name}: {ex}");

                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                var entidadeexistente = await _context.Set<T>().FindAsync(GetEntityId(entity));

                if (entidadeexistente != null)
                {
                    _context.Entry(entidadeexistente).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Entidade não encontrada para atualização.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao dar Update na Entidade {typeof(T).Name}: {ex}");

                throw;
            }
        }

        private object GetEntityId(T entity)
        {
            var property = typeof(T).GetProperty("Id");
            return property?.GetValue(entity);
        }
    }
}
