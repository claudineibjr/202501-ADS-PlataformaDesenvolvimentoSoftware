using System.Globalization;

decimal[] salarios = {
    20000m,
    150000m,
    1500m,
    0m
};

Console.WriteLine("Sem ordenação: ");
foreach (decimal salario in salarios)
{
    Console.WriteLine(salario.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
}

Array.Sort(salarios);
Array.Reverse(salarios);

Console.WriteLine("\nOrdenado decrescente: ");
foreach (decimal salario in salarios)
{
    Console.WriteLine(salario.ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
}