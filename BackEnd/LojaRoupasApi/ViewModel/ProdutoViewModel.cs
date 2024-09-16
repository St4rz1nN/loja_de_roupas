using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.ViewModel
{
    public class ProdutoViewModel
    {
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public string Tamanho { get; private set; }
        public string Cor { get; private set; }
        public decimal Valor { get; private set; }
    }
}
