namespace Ex02
{
    internal class Program
    {
        static void MostraArray(int[] idades, string ordenacao = "C")
        {
            if (ordenacao != "C" && ordenacao != "D")
            {
                Console.WriteLine("Opção de ordenação inválido");
                return;
            }

            Array.Sort(idades);

            if (ordenacao == "D")
            {
                Array.Reverse(idades);
            }

            foreach (int idade in idades)
            {
                Console.WriteLine(idade);
            }
        }

        static void Main(string[] args)
        {
            int[] idades = new int[3];

            Random rnd = new Random();
            for (int iCount = 0; iCount < idades.Length; iCount++)
            {
                idades[iCount] = rnd.Next(0, 101);
            }

            Console.Write("Ordenação - C / D: ");
            string ordenacao = Console.ReadLine();

            MostraArray(idades, ordenacao);

            Console.WriteLine("Fim!");
        }
    }
}
