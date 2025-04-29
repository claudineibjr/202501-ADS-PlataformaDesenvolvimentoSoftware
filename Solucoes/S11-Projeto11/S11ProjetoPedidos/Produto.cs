using System;

namespace S11ProjetoPedidos;

public class Produto
{
  public string Nome { get; set; }
  public decimal Preco { get; set; }

  public Produto(string nome, decimal preco)
  {
    this.Nome = nome;
    this.Preco = preco;    
  }
}
