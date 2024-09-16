using AutoMapper;
using LojaRoupasApi.Data;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.Services
{
    public class UsuarioService : BaseService<UsuarioDto, Usuario>, IUsuarioService
    {

        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
