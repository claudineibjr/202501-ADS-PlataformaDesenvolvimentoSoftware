// Exemplo de classe utilizando outra classe e com cálculo de propriedade

using System.Globalization;

public class Pessoa6
{
    public string Nome;
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

    public Pessoa6(string nome, List<Emprego> empregos)
    {
        this.Nome = nome;
        this.Empregos = empregos;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo07Pessoa6 {
  public static void Exemplo() {
    Pessoa6 pessoa = new Pessoa6("Joãoziho", [new Emprego("Amazon", "Desenvolvedor", 15000m)]);
    pessoa.Empregos.Add(new Emprego("iFood", "QA", 20000m));

    Console.WriteLine($"Nome: {pessoa.Nome}");
    Console.WriteLine($"Salário total: {pessoa.SalarioTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
  }
}