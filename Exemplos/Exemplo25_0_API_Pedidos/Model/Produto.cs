namespace WebApplication1.Model
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}
