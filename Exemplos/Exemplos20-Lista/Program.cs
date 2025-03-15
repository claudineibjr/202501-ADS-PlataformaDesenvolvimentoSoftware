using System.Collections.Generic;

namespace Exemplos20_Lista
{
    internal class Program
    {
        static void ExemploCriacao()
        {
            // Criação
            List<int> numeros1 = new List<int>();

            // Criação e atribuicao
            List<int> numeros2 = new List<int>() { 10, 20, 30 };
            List<int> numeros3 = [10, 20, 30];
        }

        static void ExemploTamanho()
        {
            // Criação
            List<int> numeros1 = new List<int>();

            Console.WriteLine($"Tamanho da lista: {numeros1.Count}");
        }

        static void ExibirValores()
        {
            List<int> numeros = [10, 20, 30];
            
            // Exemplo com for
            for (int iCount = 0; iCount < numeros.Count; iCount++)
            {
                Console.WriteLine(numeros[iCount]);
            }

            // Exemplo com foreach
            foreach(int numero in numeros)
            {
                Console.WriteLine(numero);
            }
        }

        static void ExemploAdicionar()
        {
            List<string> nomes = new List<string>();

            string novoNome = "Rubens";

            nomes.Add(novoNome);
        }

        static void ExemploAdicionarVarios()
        {
            List<string> nomes = new List<string>();

            nomes.AddRange(["Rubens", "Barrichelo"]);
        }

        static void Main(string[] args)
        {
            ExemploAdicionar();
        }
    }
}
