int[] idades = new int[6];

Random rnd = new Random();

Console.WriteLine("Idades (sem ordenação): ");
for (int iCount = 0; iCount < idades.Length; iCount++)
{
    idades[iCount] = rnd.Next(101);
    Console.WriteLine(idades[iCount]);
}

double media = idades.Average();

Array.Sort(idades);

int menoresMedia = 0;
int maioresMedia = 0;

for (int iCount = 0; iCount < idades.Length; iCount++)
{
    if (idades[iCount] < media)
    {
        menoresMedia++;
    } else
    {
        break;
    }
}
maioresMedia = idades.Length - menoresMedia;

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

int menor = idades.Min();
int maior = idades.Max();

Console.WriteLine($"\nMédia: {media}");
Console.WriteLine($"Menor: {menor}");
Console.WriteLine($"Maior: {maior}");

Console.WriteLine($"\nMenores que a média: {menoresMedia} | Maiores que a média: {maioresMedia}");