using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S11ProjetoPedidos;

public class Cliente
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Key]
  public string Id { get; set; }
  public string Nome { get; set; }
  public string CPF { get; set; }

  public Cliente(string nome, string cpf)
  {
    this.Nome = nome;
    this.CPF = cpf;
  }

  private Cliente() { }
}
