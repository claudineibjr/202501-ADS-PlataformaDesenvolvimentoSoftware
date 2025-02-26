// Ordenação
int num1 = Convert.ToInt32(Console.ReadLine());
int num2 = Convert.ToInt32(Console.ReadLine());
int num3 = Convert.ToInt32(Console.ReadLine());
string ordem = Console.ReadLine();

int maior = -1, meio = -1, menor = -1;

if (num1 > num2)
{
    if (num1 > num3)
    {
        maior = num1;
        if (num3 > num2)
        {
            meio = num3;
            menor = num2;
        } else
        {
            menor = num3;
            meio = num2;
        }
    } else
    {
        maior = num3;
        meio = num1;
        menor = num2;
    }
} else
{
    if (num2 > num3)
    {
        maior = num2;
        if(num3 > num1)
        {
            meio = num3;
            menor = num1;
        } else
        {
            meio = num1;
            menor = num3;
        }
    }
}

if (ordem == "C")
{
    Console.WriteLine($"{menor} {meio} {maior}");
} else if (ordem == "D")
{
    Console.WriteLine($"{maior} {meio} {menor}");
}