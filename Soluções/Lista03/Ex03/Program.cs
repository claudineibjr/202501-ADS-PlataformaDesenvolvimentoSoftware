// Leitura dos dados
int dia = Convert.ToInt32(Console.ReadLine());
int mes = Convert.ToInt32(Console.ReadLine());
int ano = Convert.ToInt32(Console.ReadLine());

// Cálculo
bool dataValida = true;

string textoDia = $"{dia}";
if (dia <= 9)
{
    textoDia = $"0{textoDia}";
}

string textoMes = "";
switch (mes)
{
    case 1: textoMes = "janeiro"; break;
    case 2: textoMes = "fevereiro"; break;
    case 3: textoMes = "março"; break;
    case 4: textoMes = "abril"; break;
    case 5: textoMes = "maio"; break;
    case 6: textoMes = "junho"; break;
    case 7: textoMes = "julho"; break;
    case 8: textoMes = "agosto"; break;
    case 9: textoMes = "setembro"; break;
    case 10: textoMes = "outubro"; break;
    case 11: textoMes = "novembro"; break;
    case 12: textoMes = "dezembro"; break;
    default: dataValida = false; break;
}

if (dataValida)
{
    string textoData = $"{textoDia} de {textoMes} de {ano}";

    Console.WriteLine(textoData);
}
else
{
    Console.WriteLine("Data inválida");
}