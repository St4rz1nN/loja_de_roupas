using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Models
{
    public class Usuario : Entity
    {
        public Usuario()
            => Id= Guid.NewGuid();

        public Usuario(string cpf, string nome, DateTime datanascimento, string email, string senha)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Datanascimento = datanascimento;
            this.Email = email;
            this.Senha = senha;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime Datanascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Carrinho> Carrinhos { get; set; }
    }
}
