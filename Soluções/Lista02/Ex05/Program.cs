// Leitura dos dados
decimal precoEtanol = Convert.ToDecimal(Console.ReadLine());
decimal precoGasolina = Convert.ToDecimal(Console.ReadLine());

// Cálculo
decimal percDiferenca = (precoEtanol / precoGasolina) * 100;

// Exibição
string melhorCombustivel = percDiferenca > 70 ? "Gasolina" : "Etanol";

Console.WriteLine(melhorCombustivel);