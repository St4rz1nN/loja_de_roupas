using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaRoupasApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {

        private IMapper _mapper;

        private readonly IProdutoService _produtoService;


        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [HttpPost]
        public IActionResult Add([FromForm] ProdutoDto produtoDto, IFormFile photo)
        {
            var filePath = Path.Combine("Storage", photo.FileName); //Endereço da foto

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            photo.CopyTo(fileStream);

            produtoDto.Photo = filePath;

            _produtoService.AddAsync(produtoDto);
            return CreatedAtAction(nameof(getPorId), new { id = produtoDto.Id }, produtoDto);

        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtosDto = _produtoService.GetAllAsync();
            return Ok(produtosDto);
        }

        [HttpGet("{Id}")]
        public IActionResult getPorId(Guid Id)
        {
            var produtoDto = _produtoService.GetByIdAsync(Id);
            return Ok(produtoDto);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProdutoDto produtoDto)
        {
            _produtoService.UpdateAsync(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            _produtoService.DeleteAsync(Id);
            return NoContent();
        }
    }
}
