// Exemplo de classe sem constutor
public class Carro1
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo01Carro1 {
  public static void Exemplo() {
    Carro1 carro = new Carro1();

    carro.Modelo = "Porsche Cayenne";
    carro.Ano = 2024;
    carro.Cor = "Branco";

    Console.WriteLine($"Modelo: {carro.Modelo}");
    Console.WriteLine($"Ano: {carro.Ano}");
    Console.WriteLine($"Cor: {carro.Cor}");
  }
}
