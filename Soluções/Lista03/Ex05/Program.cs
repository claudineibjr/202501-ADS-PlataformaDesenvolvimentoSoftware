using System.Globalization;

const decimal tarifaFixaAte2Horas = 5;

const decimal tarifaFixa3a5Horas = 5;
const decimal horaAdicional3a5Horas = 2;

const decimal tarifaFixaMais5Horas = 10;
const decimal horaAdicionalMais5Horas = 1.5m;

// Leitura dos dados
int tempoPermanencia = Convert.ToInt32(Console.ReadLine());

// Cálculo
decimal precoEstacionamento;

if (tempoPermanencia <= 2)
{
    precoEstacionamento = tarifaFixaAte2Horas;
}
else if (tempoPermanencia <= 5)
{
    precoEstacionamento = tarifaFixa3a5Horas + ((tempoPermanencia - 2) * horaAdicional3a5Horas);
}
else
{
    precoEstacionamento = tarifaFixaMais5Horas + ((tempoPermanencia - 5) * horaAdicionalMais5Horas);
}

// Exibição
Console.WriteLine(precoEstacionamento.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));