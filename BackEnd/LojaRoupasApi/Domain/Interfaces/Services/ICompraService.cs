using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Domain.Interfaces.Services
{
    public interface ICompraService : IBaseService<CompraDto, Compra>
    {

        public Task<Guid> AddAsync(CompraDto compradto);
        public Task<CompraDto> GetCompraByIdCarrinho(Guid IdCarrinho);

        public Task<IEnumerable<CompraDto>> GetCompraByIdUsuario(Guid IdCarrinho);
    }
}
