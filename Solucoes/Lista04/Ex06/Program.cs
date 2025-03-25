using System.Globalization;

namespace Ex06
{
    internal class Program
    {
        /*
         * 6. (Preços de produtos - Número de produtos variável) Implemente
            um programa que leia o número de produtos que o usuário quer digitar
            (X), depois disso, leia o preço de X produtos (a quantidade que o
            usuário solicitou) e faça a soma desses produtos.
            Ordem dos dados de entrada: Quantidade de produtos / Preço do produto N…*
         */
        static void Main(string[] args)
        {
            int quantidadeProdutos = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal = 0;

            decimal[] produtos = new decimal[quantidadeProdutos];
            for (int iCount = 0; iCount < quantidadeProdutos; iCount++)
            {
                produtos[iCount] = Convert.ToDecimal(Console.ReadLine());
                valorTotal += produtos[iCount];
            }

            Console.WriteLine(valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
        }
    }
}
