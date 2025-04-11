using System.Globalization;

public class Pessoa
{
  public string Nome;
  public int Idade;
  public List<Emprego> Empregos { get; set; }

  public decimal SalarioTotal
  {
    get
    {
      decimal salarioTotal = 0;

      foreach (Emprego emprego in Empregos)
      {
        salarioTotal += emprego.Salario;
      }

      return salarioTotal;
    }
  }

  public string Info
  {
    get
    {
      return $"{this.Nome} - Idade: {this.Idade} - Salário Total: {this.SalarioTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";
    }
  }

  public Pessoa(string nome, int idade, List<Emprego> empregos)
  {
    this.Nome = nome;
    this.Idade = idade;
    this.Empregos = empregos;
  }
}