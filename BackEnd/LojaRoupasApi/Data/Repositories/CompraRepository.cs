using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {

        public CompraRepository(ConnectionContext context) : base(context)
        {

        }
    }
}
