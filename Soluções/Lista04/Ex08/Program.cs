namespace Ex08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 8. (Contagem de vogais) Implemente um programa que conte o
                número de cada uma das vogais em uma frase informada pelo usuário.
                Ordem dos dados de entrada: Frase*/

            string frase = Console.ReadLine();

            int qtdA = 0, qtdE = 0, qtdI = 0, qtdO = 0, qtdU = 0;

            foreach (char letra in frase)
            {
                if (letra == 'a' || letra == 'A')
                {
                    qtdA++;
                } else if (letra == 'e' || letra == 'E')
                {
                    qtdE++;
                } else if (letra == 'i' || letra == 'I')
                {
                    qtdI++;
                } else if (letra == 'o' || letra == 'O')
                {
                    qtdO++;
                } else if (letra == 'u' || letra == 'U')
                {
                    qtdU++;
                }
            }

            Console.WriteLine(@$"A: {qtdA}
E: {qtdE}
I: {qtdI}
O: {qtdO}
U: {qtdU}");
        }
    }
}
