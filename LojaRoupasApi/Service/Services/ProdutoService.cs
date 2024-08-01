using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.Services
{
    public class ProdutoService : BaseService<ProdutoDto, Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
