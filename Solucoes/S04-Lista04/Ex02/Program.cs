decimal[] produtos = new decimal[3];

decimal somaPrecos = 0;
for (int iCount = 0; iCount < produtos.Length; iCount++)
{
    produtos[iCount] = Convert.ToDecimal(Console.ReadLine());
    somaPrecos += produtos[iCount];
}

Console.WriteLine($"{somaPrecos:f2}");