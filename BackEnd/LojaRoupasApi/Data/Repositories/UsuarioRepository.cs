using LojaRoupasApi.Data.Context;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {


        public UsuarioRepository(ConnectionContext context) : base(context) { 
        }

    }
}
