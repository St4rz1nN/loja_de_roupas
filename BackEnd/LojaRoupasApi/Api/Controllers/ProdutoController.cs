using AutoMapper;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq.Expressions;

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
        public async Task<IActionResult> Add([FromForm] ProdutoDto produtoDto, IFormFile[] photos)
        {
            Guid id = await _produtoService.AddAsync(produtoDto);

            if(photos != null)
            {

                var storagePath = Path.Combine("Storage");

                var produtoPasta = Path.Combine(storagePath, id.ToString());

                if (!Directory.Exists(produtoPasta))
                {
                    Directory.CreateDirectory(produtoPasta);
                }

                foreach (var photo in photos)
                {
                    if (photo.Length == 0)
                    {
                        continue;
                    }

                    var filePath = Path.Combine(produtoPasta, photo.FileName);

                    int fileIndex = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(photo.FileName);
                        var fileExtension = Path.GetExtension(photo.FileName);
                        var fileName = $"{fileNameWithoutExtension}_{fileIndex}{fileExtension}";
                        filePath = Path.Combine(produtoPasta, fileName);
                        fileIndex++;
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }
                }
            }
            return CreatedAtAction(nameof(GetPorId), new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPost("foto/{Id}")]
        public async Task<IActionResult> AddFotosPorId(Guid Id, IFormFile[] photos)
        {
            var storagePasta = Path.Combine("Storage");

            var produtoPasta = Path.Combine(storagePasta, Id.ToString());

            if (!Directory.Exists(produtoPasta))
            {
                Directory.CreateDirectory(produtoPasta);
            }

            foreach (var photo in photos)
            {
                if (photo.Length == 0)
                {
                    continue;
                }

                var filePath = Path.Combine(produtoPasta, photo.FileName);

                int fileIndex = 1;
                while (System.IO.File.Exists(filePath))
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(photo.FileName);
                    var fileExtension = Path.GetExtension(photo.FileName);
                    var fileName = $"{fileNameWithoutExtension}_{fileIndex}{fileExtension}";
                    filePath = Path.Combine(produtoPasta, fileName);
                    fileIndex++;
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtosDto = await _produtoService.GetAllAsync();
            return Ok(produtosDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPorId(Guid Id)
        {
            var produtoDto = await _produtoService.GetByIdAsync(Id);
            return Ok(produtoDto);
        }

        [HttpGet("foto/{Id}")]
        public async Task<IActionResult> GetFotosPorId(Guid Id)
        {
            var storagePasta = Path.Combine("Storage");

            var produtoPasta = Path.Combine(storagePasta, Id.ToString());

            if (!Directory.Exists(produtoPasta))
            {
                throw new DirectoryNotFoundException($"O diretório {produtoPasta} não foi encontrado.");
                return NotFound();
            }


            var imagens = Directory.GetFiles(produtoPasta).ToList();

            var imagensBase64 = imagens.Select(filePath =>
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var base64Image = Convert.ToBase64String(fileBytes);
                var contentType = "image/jpeg";
                return new
                {
                    fileName = Path.GetFileName(filePath),
                    dataUrl = $"data:{contentType};base64,{base64Image}"
                };
            }).ToList();

            return Ok(imagensBase64);
        }

    


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProdutoDto produtoDto, IFormFile[] photos)
        {
            await _produtoService.UpdateAsync(produtoDto);


            if (photos != null)
            {

                var storagePath = Path.Combine("Storage");

                var produtoPasta = Path.Combine(storagePath, produtoDto.Id.ToString());

                if (Directory.Exists(produtoPasta))
                {
                    Directory.Delete(produtoPasta);
                }

                if (!Directory.Exists(produtoPasta))
                {
                    Directory.CreateDirectory(produtoPasta);
                }

                foreach (var photo in photos)
                {
                    if (photo.Length == 0)
                    {
                        continue;
                    }

                    var filePath = Path.Combine(produtoPasta, photo.FileName);

                    int fileIndex = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(photo.FileName);
                        var fileExtension = Path.GetExtension(photo.FileName);
                        var fileName = $"{fileNameWithoutExtension}_{fileIndex}{fileExtension}";
                        filePath = Path.Combine(produtoPasta, fileName);
                        fileIndex++;
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }
                }
            }


            return Ok(produtoDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _produtoService.DeleteAsync(Id);

            var storagePasta = Path.Combine("Storage");

            var produtoPasta = Path.Combine(storagePasta, Id.ToString());

            if (Directory.Exists(produtoPasta))
            {
                Directory.Delete(produtoPasta, recursive:true);
            }
            return NoContent();
        }

        [HttpDelete("foto")]
        public async Task<IActionResult> DeleteFotoPorNome(Guid Id, String nome)
        {
            var storagePasta = Path.Combine("Storage");

            var produtoPasta = Path.Combine(storagePasta, Id.ToString());

            if (!Directory.Exists(produtoPasta))
            {
                throw new DirectoryNotFoundException($"O diretório {produtoPasta} não foi encontrado.");
                return NotFound();
            }

            var filePath = Path.Combine(produtoPasta, nome);

            if (!System.IO.File.Exists(filePath))
            {
                throw new DirectoryNotFoundException($"O arquivo {nome} não foi encontrado no diretorio {produtoPasta}!");
                return NotFound();
            }

            System.IO.File.Delete(filePath);

            return Ok();
        }


    }
}
