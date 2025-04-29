// Leitura dos dados
double nota = Convert.ToDouble(Console.ReadLine());

// Cálculo
string conceito;
if (nota >= 9)
{
    conceito = "MB";
}
else if (nota >= 7)
{
    conceito = "B";
}
else if (nota >= 5)
{
    conceito = "R";
}
else
{
    conceito = "I";
}

// Exibição
Console.WriteLine(conceito);