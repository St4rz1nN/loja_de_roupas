using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LojaRoupasApi.Api.Controllers
{

    [ApiController]
    [Route("api/v1/carrinho")]
    public class CarrinhoController : ControllerBase
    {

        private readonly ICarrinhoService _carrinhoService;
        private readonly IMapper _mapper;
        public CarrinhoController(ICarrinhoService carrinhoService, IMapper mapper)
        {
            _carrinhoService = carrinhoService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CarrinhoDto carrinhoDto)
        {

            _carrinhoService.AddAsync(carrinhoDto);

            return CreatedAtAction(nameof(getPorId), new { id = carrinhoDto.IdUsuario }, carrinhoDto);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var carrinhosDto = _carrinhoService.GetAllAsync();
            return Ok(carrinhosDto);
        }

        [HttpGet("{id}")]

        public IActionResult getPorId(Guid id)
        {
            var carrinhoDto = _carrinhoService.GetByIdAsync(id);
            return Ok(carrinhoDto);
        }

        [HttpGet("{idusuario}")]

        public IActionResult getPorIdUsuario(Guid idusuario)
        {
            var carrinhoDto = _carrinhoService.GetCarrinhoByIdUsuario(idusuario);

            if (carrinhoDto == null)
            {
                return NotFound(); // Retorna não encontrado!
            }
            return Ok(carrinhoDto); // Retorna o carrinho!
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            _carrinhoService.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut]

        public IActionResult Update([FromBody] CarrinhoDto carrinhoDto)
        {
            _carrinhoService.UpdateAsync(carrinhoDto);
            return Ok(carrinhoDto);
        }

        [HttpGet("GetItemsByIdCarrinho")]
        public IActionResult GetItemsByIdCarrinho(Guid Id)
        {
            var items = _carrinhoService.ListarItemsByIdCarrinho(Id);

            return Ok(items);
        }

    }
}
