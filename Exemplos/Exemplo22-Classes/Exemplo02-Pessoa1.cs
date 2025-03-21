// Exemplo de classe com construtor e propriedades,
// além de omissão do método set na propriedade Idade
public class Pessoa1
{
    public string Nome { get; set; }
    public int Idade { get; }

    public Pessoa1(string nome, int idade)
    {
        this.Nome = nome;
        this.Idade = idade;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo02Pessoa1 {
  public static void Exemplo() {
    Pessoa1 pessoa = new Pessoa1("Estevão", 17);

    pessoa.Nome = "Estevão Willian";
    // pessoa.Idade = 18; // Não funciona

    Console.WriteLine($"Nome: {pessoa.Nome}");
    Console.WriteLine($"Idade: {pessoa.Idade}");
  }
}
