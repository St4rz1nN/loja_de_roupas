using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Entities.Base;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaRoupasApi.Data.Repositories
{
    public class ItemCarrinhoRepository : BaseRepository<ItemCarrinho>, IItemCarrinhoRepository
    {

        public ItemCarrinhoRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
