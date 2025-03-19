namespace Ex04
{
    internal class Program
    {

        static int ContaPalavas(string frase)
        {
            string[] palavras = frase.Split(" ");
            return palavras.Length;
        }

        static void Main(string[] args)
        {
            string frase = Console.ReadLine();
            int palavras = ContaPalavas(frase);

            Console.WriteLine($"Palavras: {palavras}");
        }
    }
}
