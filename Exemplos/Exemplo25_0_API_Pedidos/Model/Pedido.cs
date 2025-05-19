using Exemplo25_0_API_Pedidos.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Model;

namespace WebApplication1.Model
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public DateTime Data { get; set; }
        public decimal ValorTotal { get {
                return this.Produtos.Sum(p => p.Preco);
           }
        }

        public Pedido(List<Produto> produtos, Cliente cliente, DateTime data)
        {
            this.Produtos = produtos;
            this.Cliente = cliente;
            this.Data = data;
        }

        private Pedido() { }
    }
}
