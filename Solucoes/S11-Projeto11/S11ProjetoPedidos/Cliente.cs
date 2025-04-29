namespace S11ProjetoPedidos;

public class Cliente
{
  public string Nome { get; set; }
  public string CPF { get; set; }

  public Cliente(string nome, string cpf)
  {
    this.Nome = nome;
    this.CPF = cpf;
  }
}
