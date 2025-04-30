using System;

namespace S11ProjetoPedidos;

public class Pedido
{
  public Cliente Cliente { get; set; }
  public List<Produto> Produtos { get; set; }
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
}
