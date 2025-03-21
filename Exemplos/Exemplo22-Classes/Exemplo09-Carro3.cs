// Exemplo de classe com métodos mais complexos
public class Carro3
{
    public string Modelo { get; set; }
    public int VelocidadeAtual { get; private set; }
    private int velocidadeMaxima;

    private static int variacaoVelocidade = 25;

    public Carro3(string modelo, int velocidadeMaxima)
    {
        this.Modelo = modelo;
        this.velocidadeMaxima = velocidadeMaxima;
        this.VelocidadeAtual = 0;
    }

    public string ExibirInformacoes()
    {
        return $"Modelo: {Modelo} | Velocidade atual: {VelocidadeAtual}";
    }

    public void Acelerar()
    {
        if (VelocidadeAtual + variacaoVelocidade > velocidadeMaxima)
        {
            this.VelocidadeAtual = velocidadeMaxima;
        }
        else
        {
            this.VelocidadeAtual += variacaoVelocidade;
        }
    }

    public void Frear()
    {
        if (this.VelocidadeAtual - variacaoVelocidade < 0)
        {
            this.VelocidadeAtual = 0;
        }
        else
        {
            this.VelocidadeAtual -= variacaoVelocidade;
        }
    }
}

// Classe usada apenas para exemplificar/testar a classe criada acima.
public class Exemplo09Carro3 {
  public static void Exemplo() {
    Carro3 carro = new Carro3("Porsche Cayenne", 80);

    // Velocidade 0
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 0 >> 25
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 25 >> 50
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 50 >> 75
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 75 >> 80
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 80 >> 80
    carro.Acelerar();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 80 >> 55
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 55 >> 30
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 30 >> 5
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 5 >> 0
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());

    // Velocidade 0 >> 0
    carro.Frear();
    Console.WriteLine(carro.ExibirInformacoes());
  }
}