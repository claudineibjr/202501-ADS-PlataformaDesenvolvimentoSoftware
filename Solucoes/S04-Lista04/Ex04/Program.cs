int num = Convert.ToInt32(Console.ReadLine());

int fatorial = 1;
if (num > 0)
{
    for (int iCount = 1; iCount <= num; iCount++)
    {
        fatorial = iCount * fatorial;
    }
}
else if (num < 0)
{
    Console.WriteLine("Entrada inválida");
}

Console.WriteLine($"{num}! = {fatorial}");