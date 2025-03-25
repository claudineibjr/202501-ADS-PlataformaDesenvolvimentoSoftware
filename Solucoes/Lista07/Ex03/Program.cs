using System.Globalization;

namespace Ex03
{
    internal class Program
    {
        static string FormataComoMoeda(decimal valor)
        {
            return valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }

        static decimal PagamentoPix(decimal valorTotal)
        {
            decimal percDesconto = 7;

            return valorTotal - (valorTotal * percDesconto / 100);
        }

        static decimal PagamentoDinheiro(decimal valorTotal)
        {
            decimal percDesconto = 5;

            return valorTotal - (valorTotal * percDesconto / 100);
        }

        static decimal PagamentoDebito(decimal valorTotal)
        {
            return valorTotal;
        }

        static decimal PagamentoCredito(decimal valorTotal, int parcelas)
        {
            decimal percAcrescimo = 0;
            if (parcelas > 10)
            {
                percAcrescimo = 7;
            }
            else if (parcelas > 5)
            {
                percAcrescimo = 5;
            }

            return valorTotal + (valorTotal * percAcrescimo / 100);
        }

        static void CalculaEExibeValorFinal(decimal valorTotal, string formaPagamento)
        {
            decimal valorFinal = 0;

            switch (formaPagamento)
            {
                case "P":
                    {
                        valorFinal = PagamentoPix(valorTotal);
                        Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

                        break;
                    }

                case "D":
                    {
                        valorFinal = PagamentoDinheiro(valorTotal);
                        Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

                        break;
                    }

                case "CD":
                    {
                        valorFinal = PagamentoDebito(valorTotal);
                        Console.WriteLine($"Valor final: {valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

                        break;
                    }

                case "CC":
                    {
                        int parcelas = Convert.ToInt32(Console.ReadLine());
                        valorFinal = PagamentoCredito(valorTotal, parcelas);

                        decimal valorParcela = valorFinal / parcelas;

                        Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))} em {parcelas} parcelas de {valorParcela.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

                        break;
                    }

                default:
                    Console.WriteLine("Forma de pagamento inválida");
                    break;
            }
        }

        static void Main(string[] args)
        {
            // Produto 1
            string produto1 = Console.ReadLine();
            decimal valor1 = Convert.ToDecimal(Console.ReadLine());
            int quantidade1 = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal1 = valor1 * quantidade1;

            // Produto 2
            string produto2 = Console.ReadLine();
            decimal valor2 = Convert.ToDecimal(Console.ReadLine());
            int quantidade2 = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal2 = valor2 * quantidade2;

            // Produto 3
            string produto3 = Console.ReadLine();
            decimal valor3 = Convert.ToDecimal(Console.ReadLine());
            int quantidade3 = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal3 = valor3 * quantidade3;

            // Final
            decimal valorTotal = valorTotal1 + valorTotal2 + valorTotal3;

            string mensagem = @$"Total: {FormataComoMoeda(valorTotal)}
 - {quantidade1}x {produto1} - {FormataComoMoeda(valorTotal1)}
 - {quantidade2}x {produto2} - {FormataComoMoeda(valorTotal2)}
 - {quantidade3}x {produto3} - {FormataComoMoeda(valorTotal3)}";

            Console.WriteLine(mensagem);

            // Forma de pagamento
            string formaPgto = Console.ReadLine();
            CalculaEExibeValorFinal(valorTotal, formaPgto);
        }
    }
}
