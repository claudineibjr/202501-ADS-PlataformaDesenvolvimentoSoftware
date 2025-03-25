namespace Ex02
{
    internal class Program
    {
        static double LerNota()
        {
            do
            {
                try
                {
                    Console.Write("Digite a nota: ");
                    double nota = Convert.ToDouble(Console.ReadLine());

                    if (nota < 0 || nota > 10)
                    {
                        throw new Exception("Nota inválida. A nota deve ser entre 0 e 10");
                    }

                    return nota;
                }
                catch
                {
                    Console.WriteLine("Nota inválida.");
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            try
            {
                double nota1 = LerNota();
                double nota2 = LerNota();

                double media = (nota1 + nota2) / 2;
                Console.Write($"Nota final: {media}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao calcular a nota.\n{ex.Message}");
            }
        }
    }
}
