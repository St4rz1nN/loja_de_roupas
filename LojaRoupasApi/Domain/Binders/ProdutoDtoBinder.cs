using LojaRoupasApi.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class ProdutoDtoBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var request = bindingContext.HttpContext.Request;

        // Verifica o Content-Type da requisição
        var contentType = request.ContentType.ToLowerInvariant();

        if (contentType.StartsWith("application/json"))
        {
            // Se o Content-Type for JSON, lê o corpo da requisição como JSON
            using (var reader = new StreamReader(request.Body))
            {
                var jsonString = await reader.ReadToEndAsync();

                try
                {
                    // Deserializa o JSON para o modelo ProdutoDto
                    var produtoDto = JsonConvert.DeserializeObject<ProdutoDto>(jsonString);

                    // Define o modelo como o resultado do binding
                    bindingContext.Result = ModelBindingResult.Success(produtoDto);
                }
                catch
                {
                    // Retorna erro se houver problema ao desserializar o JSON
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
        }
        else if (contentType.StartsWith("multipart/form-data"))
        {
            // Se o Content-Type for Formulário, lê os campos do formulário
            var produtoDto = new ProdutoDto();

            produtoDto.Tipo = request.Form["Tipo"];
            produtoDto.Tamanho = request.Form["Tamanho"];
            produtoDto.Cor = request.Form["Cor"];

            // Manipula o arquivo se ele existir
            var file = request.Form.Files.GetFile("Photo");
            if (file != null && file.Length > 0)
            {
                // Aqui você pode processar o arquivo conforme necessário
                // Por exemplo, salvar o arquivo em um local específico
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    produtoDto.Photo = file.FileName; // Você pode ajustar isso conforme necessário
                }
            }

            // Define o modelo como o resultado do binding
            bindingContext.Result = ModelBindingResult.Success(produtoDto);
        }
        else
        {
            // Se o Content-Type não for suportado, retorna um erro
            bindingContext.Result = ModelBindingResult.Failed();
        }
    }
}