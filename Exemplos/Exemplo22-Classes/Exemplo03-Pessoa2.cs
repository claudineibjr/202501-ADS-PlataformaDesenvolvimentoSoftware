// Exemplo de cálculo de propriedade no construtor
public class Pessoa2
{
    public string NomeCompleto { get; set; }
    public int Idade { get; }

    public Pessoa2(string nome, string sobrenome, int idade)
    {
        this.NomeCompleto = $"{nome} {sobrenome}";
        this.Idade = idade;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo03Pessoa2 {
  public static void Exemplo() {
    Pessoa2 pessoa = new Pessoa2("Estevão", "Willian", 17);

    Console.WriteLine($"Nome: {pessoa.NomeCompleto}");
    Console.WriteLine($"Idade: {pessoa.Idade}");
  }
}
