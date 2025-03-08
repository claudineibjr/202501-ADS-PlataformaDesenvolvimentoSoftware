string[] nomes = { "Vitor Roque", "Paulinho", "Estevão" };

Console.WriteLine($"Tamanho: {nomes.Length}");
foreach (string nome in nomes)
{
    Console.WriteLine(nome);
}

// Redimensiona
Array.Resize(ref nomes, 5);
Console.WriteLine($"\nNovo Tamanho: {nomes.Length}");
foreach (string nome in nomes)
{
    Console.WriteLine($"Nome: {nome}");
}