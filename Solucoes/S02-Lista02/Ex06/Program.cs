// Leitura dos dados
decimal precoEtanol = Convert.ToDecimal(Console.ReadLine());
double consumoEtanol = Convert.ToDouble(Console.ReadLine());

decimal precoGasolina = Convert.ToDecimal(Console.ReadLine());
double consumoGasolina = Convert.ToDouble(Console.ReadLine());

// Cálculo
decimal custoPorKMEtanol = precoEtanol / (decimal)consumoEtanol;
decimal custoPorKMGasolina = precoGasolina / (decimal)consumoGasolina;

// Exibição
string melhorCombustivel;
if (custoPorKMEtanol < custoPorKMGasolina) {
  melhorCombustivel = "Etanol";
} else if (custoPorKMGasolina < custoPorKMEtanol) {
  melhorCombustivel = "Gasolina";
} else {
  melhorCombustivel = "Empate";
}

Console.WriteLine(melhorCombustivel);