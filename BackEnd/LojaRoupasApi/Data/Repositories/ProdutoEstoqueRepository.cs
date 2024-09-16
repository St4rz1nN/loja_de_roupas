using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class ProdutoEstoqueRepository : BaseRepository<ProdutoEstoque>, IProdutoEstoqueRepository
    {

        public ProdutoEstoqueRepository(ConnectionContext context) : base(context)
        {

        }
    }
}
