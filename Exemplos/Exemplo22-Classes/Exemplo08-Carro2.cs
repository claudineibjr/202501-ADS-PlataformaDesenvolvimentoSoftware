// Exemplo de classe com métodos

public class Carro2
{
    public string Modelo { get; set; }
    public int VelocidadeAtual { get; private set; }

    public Carro2(string modelo)
    {
        this.Modelo = modelo;
        this.VelocidadeAtual = 0;
    }

    public string ExibirInformacoes()
    {
        return $"Modelo: {Modelo} | Velocidade atual: {VelocidadeAtual}";
    }

    public void Acelerar()
    {
        this.VelocidadeAtual += 25;
    }

    public void Frear()
    {
        this.VelocidadeAtual -= 25;
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo08Carro2 {
  public static void Exemplo() {
    Carro2 carro = new Carro2("Porsche Cayenne");

    // Velocidade 0
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 0 >> 25
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 25 >> 50
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 50 >> 25
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());
  }
}