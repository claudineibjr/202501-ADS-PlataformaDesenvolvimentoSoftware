int[] idades = new int[20];

Random rnd = new Random();

Console.WriteLine("Idades (sem ordenação): ");
for (int iCount = 0; iCount < idades.Length; iCount++)
{
    idades[iCount] = rnd.Next(101);
    Console.WriteLine(idades[iCount]);
}

Array.Sort(idades);

Console.Write("\nOrdenação - C Crescente / D Decrescente: ");
string formaOrdenacao = Console.ReadLine();
if (formaOrdenacao == "D")
{
    Array.Reverse(idades);
}

Console.WriteLine($"\nIdades (com ordenação): {formaOrdenacao}");

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

int maioresMedia = 0;
int menoresMedia = 0;

foreach(int idade in idades)
{
    if (idade > media)
    {
        maioresMedia++;
    } else
    {
        menoresMedia++;
    }
}

Console.WriteLine($"\nMenores que a média: {menoresMedia} | Maiores que a média: {maioresMedia}");