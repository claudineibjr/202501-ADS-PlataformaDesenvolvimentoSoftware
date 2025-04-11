using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

public class Pessoa
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Key]
  public string Id { get; set; }
  public string Nome { get; set; }
  public int Idade { get; set; }
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

  private Pessoa() { }
}