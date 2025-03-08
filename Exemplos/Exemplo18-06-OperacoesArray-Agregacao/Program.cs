decimal[] salarios = {
    20000m,
    150000m,
    1500m,
    0m
};

decimal media = salarios.Average();
decimal menor = salarios.Min();
decimal maior = salarios.Max();
decimal soma = salarios.Sum();

Console.WriteLine(@$"Média: {media}
Menor: {menor}
Maior: {maior}
Soma: {soma}");