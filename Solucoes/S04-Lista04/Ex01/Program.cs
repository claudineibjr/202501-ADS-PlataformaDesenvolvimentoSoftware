int[] idades = new int[5];

double somaIdades = 0;
for (int iCount = 0; iCount < idades.Length; iCount++)
{
    idades[iCount] = Convert.ToInt32(Console.ReadLine());
    somaIdades += idades[iCount];
}

double media = somaIdades / idades.Length;

Console.WriteLine($"{media:f2}");