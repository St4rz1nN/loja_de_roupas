using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class CarrinhoRepository : BaseRepository<Carrinho>, ICarrinhoRepository
    {

        public CarrinhoRepository(ConnectionContext context) : base(context){ 
            
        }
    }
}
