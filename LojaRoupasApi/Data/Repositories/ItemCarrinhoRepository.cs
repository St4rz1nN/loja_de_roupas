using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class ItemCarrinhoRepository : BaseRepository<ItemCarrinho>, IItemCarrinhoRepository
    {

        public ItemCarrinhoRepository(ConnectionContext context) : base(context)
        {

        }
    }
}
