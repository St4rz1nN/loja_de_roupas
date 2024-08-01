
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;

namespace LojaRoupasApi.Api.Controllers
{


    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private IMapper _mapper;

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] UsuarioDto usuarioDto)
        {
            _usuarioService.AddAsync(usuarioDto);
            return CreatedAtAction(nameof(GetById), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usuariosDto = _usuarioService.GetAllAsync();

            return Ok(usuariosDto);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UsuarioDto usuarioDto)
        {
            _usuarioService.UpdateAsync(usuarioDto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _usuarioService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var usuarioDto = _usuarioService.GetByIdAsync(id);

            return Ok(usuarioDto);
        }
    }
}
