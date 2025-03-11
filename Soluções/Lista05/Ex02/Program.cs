﻿int[] idades = new int[20];

Random rnd = new Random();

for (int iCount = 0; iCount < idades.Length; iCount++)
{
    idades[iCount] = rnd.Next(101);
    Console.WriteLine($"{iCount + 1}ª idade: {idades[iCount]}");
}

double media = idades.Average();
int menor = idades.Min();
int maior = idades.Max();

Console.WriteLine($"Média: {media}");
Console.WriteLine($"Menor: {menor}");
Console.WriteLine($"Maior: {maior}");
