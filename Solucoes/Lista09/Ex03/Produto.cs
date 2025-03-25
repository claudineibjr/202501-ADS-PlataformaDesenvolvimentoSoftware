using System.Globalization;

namespace Ex03
{
    internal class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string PrecoFormatadoParaMoeda
        {
            get
            {
                return this.Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
            }
        }

        public Produto(string Nome, decimal Preco, int QuantidadeDisponivel)
        {
            this.Nome = Nome;
            this.Preco = Preco;
            this.QuantidadeDisponivel = QuantidadeDisponivel;
        }

        public string ExibirInformacoes()
        {
            return $"{this.Nome} {PrecoFormatadoParaMoeda} ({this.QuantidadeDisponivel})";
        }
    }
}
