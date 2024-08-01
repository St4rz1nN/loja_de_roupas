using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Domain.Interfaces.Services
{
    public interface IProdutoEstoqueService : IBaseService<ProdutoEstoqueDto, ProdutoEstoque>
    {
    }
}
