using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaRoupasApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Compra")]
    public class CompraController : ControllerBase
    {

        private readonly ICompraService _CompraService;
        private readonly IMapper _mapper;
        public CompraController(ICompraService CompraService, IMapper mapper)
        {
            _CompraService = CompraService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CompraDto CompraDto)
        {
            _CompraService.AddAsync(CompraDto);

            return CreatedAtAction(nameof(GetById), new { id = CompraDto.Id }, CompraDto);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var ComprasDto = _CompraService.GetAllAsync();
            return Ok(ComprasDto);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var CompraDto = _CompraService.GetByIdAsync(id);
            return Ok(CompraDto);
        }

        [HttpGet("{IdCarrinho}")]
        public IActionResult GetByIdCarrinho(Guid IdCarrinho)
        {
            var ComprasDto = _CompraService.GetCompraByIdCarrinho(IdCarrinho);
            return Ok(ComprasDto);
        }

        [HttpGet("{IdUsuario}")]
        public IActionResult GetByIdUsuario(Guid IdUsuario)
        {
            var ComprasDto = _CompraService.GetCompraByIdUsuario(IdUsuario);
            return Ok(ComprasDto);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            _CompraService.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut]

        public IActionResult Update([FromBody] CompraDto CompraDto)
        {
            _CompraService.UpdateAsync(CompraDto);
            return Ok(CompraDto);
        }



    }
}
