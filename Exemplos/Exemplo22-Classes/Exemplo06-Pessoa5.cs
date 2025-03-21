// Exemplo de classe utilizando outra classe
using System.Globalization;

public class Pessoa5
{
    public string Nome;
    public Emprego Emprego { get; set; }

    public Pessoa5(string nome, Emprego emprego)
    {
        this.Nome = nome;
        this.Emprego = emprego;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo06Pessoa5 {
  public static void Exemplo() {
    Pessoa5 pessoa = new Pessoa5("Joãozinho", new Emprego("Amazon", "Desenvolvedor", 15000m));

    Console.WriteLine($"Nome: {pessoa.Nome}");
    Console.WriteLine($"Emprego: {pessoa.Emprego.Cargo} ({pessoa.Emprego.Empresa})");
    Console.WriteLine($"Salário: {pessoa.Emprego.Salario.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
  }
}