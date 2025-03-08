string[] nomes = { "Vitor Roque", "Paulinho", "Estevão" };

Console.Write("Digite o nome a buscar: ");
string nomeBuscado = Console.ReadLine();

int indice = Array.IndexOf(nomes, nomeBuscado);

Console.WriteLine($"Índice encontrado: {indice}");