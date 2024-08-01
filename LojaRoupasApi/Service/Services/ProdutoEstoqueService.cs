using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.Services
{
    public class ProdutoEstoqueService : BaseService<ProdutoEstoqueDto, ProdutoEstoque>, IProdutoEstoqueService
    {

        private readonly IProdutoEstoqueRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoEstoqueService(IProdutoEstoqueRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
