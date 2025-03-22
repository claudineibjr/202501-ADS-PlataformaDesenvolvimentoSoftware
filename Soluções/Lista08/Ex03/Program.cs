using System.Globalization;

namespace Ex03
{
    internal class Program
    {
        static string FormataComoMoeda(decimal valor)
        {
            return valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }

        static void Main(string[] args)
        {
            /*
                3. (Caixa de supermercado) Implemente um programa que crie uma
                lista e armazene o preço de produtos passados no caixa do
                supermercado. O programa deve continuar lendo o preço dos produtos
                até que o preço digitado seja -1. Exiba o valor final da compra e a
                quantidade de produtos.
             */

            List<decimal> precos = new List<decimal>();

            decimal novoPreco = -1;

            do
            {
                Console.Write("Digite o preço do produto (-1 para sair): ");
                novoPreco = Convert.ToDecimal(Console.ReadLine());
                if (novoPreco != -1)
                {
                    precos.Add(novoPreco);
                }

            } while (novoPreco != -1);

            Console.WriteLine($"Valor final: {FormataComoMoeda(precos.Sum())}");
        }
    }
}
