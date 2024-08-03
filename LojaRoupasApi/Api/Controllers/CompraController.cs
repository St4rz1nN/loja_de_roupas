using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
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

            return CreatedAtAction(nameof(getPorId), new { id = CompraDto.Id }, CompraDto);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var ComprasDto = _CompraService.GetAllAsync();
            return Ok(ComprasDto);
        }

        [HttpGet("{id}")]

        public IActionResult getPorId(Guid id)
        {
            var CompraDto = _CompraService.GetByIdAsync(id);
            return Ok(CompraDto);
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
