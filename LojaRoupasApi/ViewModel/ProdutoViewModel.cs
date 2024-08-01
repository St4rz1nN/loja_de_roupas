namespace LojaRoupasApi.ViewModel
{
    public class ProdutoViewModel
    {

        public string Tipo { get; private set; }

        public string Tamanho { get; private set; }

        public string Cor { get; private set; }

        public IFormFile Photo { get; private set; }
    }
}
