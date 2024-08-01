using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {   


        public ProdutoRepository(ConnectionContext context) : base(context)
        {

        }

    }
}
