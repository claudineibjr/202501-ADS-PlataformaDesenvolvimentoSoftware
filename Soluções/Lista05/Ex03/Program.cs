int[] idades = new int[20];

Random rnd = new Random();

Console.WriteLine("Idades (sem ordenação): ");
for (int iCount = 0; iCount < idades.Length; iCount++)
{
    idades[iCount] = rnd.Next(101);
    Console.WriteLine(idades[iCount]);
}
    
Console.WriteLine("\nIdades (com ordenação): ");
Array.Sort(idades);
foreach (int idade in idades)
{
    Console.WriteLine(idade);
}

double media = idades.Average();
int menor = idades.Min();
int maior = idades.Max();

Console.WriteLine($"\nMédia: {media}");
Console.WriteLine($"Menor: {menor}");
Console.WriteLine($"Maior: {maior}");
