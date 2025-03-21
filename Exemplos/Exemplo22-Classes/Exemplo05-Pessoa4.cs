// Exemplo de cálculo de propriedade na leitura e escrita
public class Pessoa4
{
    private string nome; // Campo

    public string Nome // Propriedade
    {
        get { return nome.ToUpper(); } // Retorna sempre em maiúsculas
        set { nome = value.Trim(); } // Remove espaços extras
    }

    public Pessoa4(string nome) {
      this.Nome = nome;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo05Pessoa4 {
  public static void Exemplo() {
    Pessoa4 pessoa = new Pessoa4("     Estevão Willian          ");

    Console.WriteLine($"Nome: {pessoa.Nome}");
  }
}