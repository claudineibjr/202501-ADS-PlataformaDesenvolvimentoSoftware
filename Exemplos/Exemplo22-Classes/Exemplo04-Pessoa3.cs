// Exemplo de propriedade privada estática e cálculo de propriedade
public class Pessoa3
{
    private static int idadeMaioridade = 18;

    public string Nome { get; set; }
    public int Idade { get; set; }
    public bool MaiorDeIdade
    {
        get { return Idade >= Pessoa3.idadeMaioridade; }
    }

    public Pessoa3(string nome, int idade) {
      this.Nome = nome;
      this.Idade = idade;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo04Pessoa3 {

  public static void ExibeInformacoes(Pessoa3 pessoa) {
        Console.WriteLine(@$" - Nome: {pessoa.Nome}
 - Idade: {pessoa.Idade}
 - Maior de idade: {(pessoa.MaiorDeIdade ? "Sim" : "Não")}
");
  }

  public static void Exemplo() {
    Pessoa3 pessoaEstevao = new Pessoa3("Estevão Willian", 17);
    Console.WriteLine("Jogador 1: ");
    ExibeInformacoes(pessoaEstevao);

    Pessoa3 pessoaEndrick = new Pessoa3("Endrick Felipe", 18);
    Console.WriteLine("Jogador 2: ");
    ExibeInformacoes(pessoaEndrick);
  }
}