using LojaRoupasApi.Domain.Dto.Base;
using LojaRoupasApi.Domain.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Dto
{
    public class UsuarioDto : BaseDto
    {
        public UsuarioDto()
            => Id= Guid.NewGuid();

        public UsuarioDto(string cpf, string nome, DateTime datanascimento, string email, string senha)
        {
            this.Cpf= cpf;
            this.Nome= nome;
            this.Datanascimento = datanascimento;
            this.Email= email;
            this.Senha= senha;

        }

        [Required(ErrorMessage = "O Campo CPF é Obrigatorio!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo datanascimento é Obrigatorio!")]
        public DateTime Datanascimento { get; set; }

        [Required(ErrorMessage = "O Campo email é Obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo senha é Obrigatorio!")]
        public string Senha { get; set; }
    }
}
