// Produto 1
using System.Globalization;

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

string mensagem = @$"Total: {valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - {quantidade1}x {produto1} - {valorTotal1.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - {quantidade2}x {produto2} - {valorTotal2.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - {quantidade3}x {produto3} - {valorTotal3.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}";

Console.WriteLine(mensagem);

// Forma de pagamento
string formaPgto = Console.ReadLine();
switch (formaPgto)
{
    case "P":
        {
            decimal percDesconto = 7;

            decimal valorFinal = valorTotal - (valorTotal * percDesconto / 100);
            Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            break;
        }

    case "D":
        {
            decimal percDesconto = 5;

            decimal valorFinal = valorTotal - (valorTotal * percDesconto / 100);
            Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            break;
        }

    case "CD":
        {
            Console.WriteLine($"Valor final: {valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            break;
        }

    case "CC":
        {
            int parcelas = Convert.ToInt32(Console.ReadLine());

            decimal percAcrescimo = 0;
            if (parcelas > 10)
            {
                percAcrescimo = 7;
            }
            else if (parcelas > 5)
            {
                percAcrescimo = 5;
            }

            decimal valorFinal = valorTotal + (valorTotal * percAcrescimo / 100);

            decimal valorParcela = valorFinal / parcelas;

            Console.WriteLine($"Valor final: {valorFinal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))} em {parcelas} parcelas de {valorParcela.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            break;
        }
}