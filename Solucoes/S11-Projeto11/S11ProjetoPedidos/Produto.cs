using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S11ProjetoPedidos;

public class Produto
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Key]
  public string Id { get; set; }
  public string Nome { get; set; }
  public decimal Preco { get; set; }

  public Produto(string nome, decimal preco)
  {
    this.Nome = nome;
    this.Preco = preco;    
  }

  private Produto() { }
}
