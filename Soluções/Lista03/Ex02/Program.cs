// Leitura dos dados
int ano = Convert.ToInt32(Console.ReadLine());

// Cálculo
bool divisivelPor4 = ano % 4 == 0;
bool divisivelPor100 = ano % 100 == 0;
bool divisivelPor400 = ano % 400 == 0;

bool bissexto;
if ((divisivelPor4 && !divisivelPor100) || divisivelPor400)
{
    bissexto = true;
}
else
{
    bissexto = false;
}

// Exibição
Console.WriteLine(bissexto ? "Bissexto" : "Não bissexto");