using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LojaRoupasApi.Api.Controllers
{

    [ApiController]
    [Route("api/v1/ItemCarrinho")]
    public class ItemCarrinhoController : ControllerBase
    {

        private readonly IItemCarrinhoService _ItemCarrinhoService;
        private readonly IMapper _mapper;
        public ItemCarrinhoController(IItemCarrinhoService ItemCarrinhoService, IMapper mapper)
        {
            _ItemCarrinhoService = ItemCarrinhoService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ItemCarrinhoDto ItemCarrinhoDto)
        {
            _ItemCarrinhoService.AddAsync(ItemCarrinhoDto);

            return CreatedAtAction(nameof(getPorId), new { id = ItemCarrinhoDto.Id }, ItemCarrinhoDto);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ItemCarrinhosDto = _ItemCarrinhoService.GetAllAsync();
            return Ok(ItemCarrinhosDto);
        }

        [HttpGet("{id}")]

        public IActionResult getPorId(Guid id)
        {
            var ItemCarrinhoDto = _ItemCarrinhoService.GetByIdAsync(id);
            return Ok(ItemCarrinhoDto);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            _ItemCarrinhoService.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut]

        public IActionResult Update([FromBody] ItemCarrinhoDto ItemCarrinhoDto)
        {
            _ItemCarrinhoService.UpdateAsync(ItemCarrinhoDto);
            return Ok(ItemCarrinhoDto);
        }

        [HttpPut("{Id}")]

        public IActionResult Remover(Guid Id)
        {
            _ItemCarrinhoService.RemoverPorIdAsync(Id);
            return Ok(Id);
        }
    }
}
