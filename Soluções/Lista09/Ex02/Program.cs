namespace Ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> carros = new List<Carro>();

            // Opção 3
            carros.Add(new Carro("Ferrari Purosangue", 2025));
            carros.Add(new Carro("Nissan Sentra", 2024));
            carros.Add(new Carro("VW Fusca", 1980));

            // Listagem
            foreach(Carro carro in carros) {
                Console.WriteLine(carro.ObterInformacoes());
            }
        }
    }
}
