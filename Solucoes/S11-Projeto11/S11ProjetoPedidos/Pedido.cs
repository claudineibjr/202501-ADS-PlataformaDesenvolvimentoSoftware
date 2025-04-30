using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S11ProjetoPedidos;

public class Pedido
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Key]
  public string Id { get; set; }
  public Cliente Cliente { get; set; }
  public List<Produto> Produtos { get; set; } = new();
  public DateOnly Data { get; set; }
  public decimal ValorTotal {
    get {
      return Produtos.Sum(produto => produto.Preco);
    }
  }

  public Pedido(Cliente cliente, List<Produto> produtos)
  {
    this.Cliente = cliente;
    this.Produtos = produtos;
  }

  private Pedido() { }
}
