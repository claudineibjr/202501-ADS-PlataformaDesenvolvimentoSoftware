using System.Globalization;

// -------------------------------
// --- Formatação string --------- 
// -------------------------------
string nome = "Claudinei Brito Junior";

Console.WriteLine("Hello {0} - World", nome);

Console.WriteLine($"Hello {nome} - World");

string mensagemBoasVindas1 = string.Format("Hello {0} - World", nome);
Console.WriteLine(mensagemBoasVindas1);

string mensagemBoasVindas2 = $"Hello {nome} - World";
Console.WriteLine(mensagemBoasVindas2);

// -----------------------------------------
// --- Formatação de números reais --------- 
// -----------------------------------------
double altura = 1.7d;

Console.WriteLine($"Altura: {altura:f2}");

// ----------------------------------
// --- Formatação monetária --------- 
// ----------------------------------
double salario = 32794.05d;  // Trinta e dois mil, setecentos e noventa e quatro reais e cinco centavos

string textoSalario1 = salario.ToString("C");
Console.WriteLine($"Expectativa salarial: {textoSalario1}");

string textoSalario2 = salario.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
Console.WriteLine($"Expectativa salarial: {textoSalario2}");