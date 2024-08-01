using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<Carrinho, CarrinhoDto>()
                .ReverseMap();

            CreateMap<Compra, CompraDto>()
                .ReverseMap();

            CreateMap<ItemCarrinho, ItemCarrinhoDto>()
                .ReverseMap();

            CreateMap<ProdutoEstoque, ProdutoEstoqueDto>()
                .ReverseMap();

            CreateMap<Produto, ProdutoDto>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
        }

    }
}
