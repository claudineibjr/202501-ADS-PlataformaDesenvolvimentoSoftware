/*5. (Menor e maior idade entre os alunos) Incremente o programa
Média de idade - Número de alunos fixo (5 alunos), de forma a identificar a
menor e a maior idade entre os alunos.*/

int[] idades = new int[5];
int somaIdades = 0;

int maior = 0, menor = 0;

for (int iCount = 0; iCount < idades.Length; iCount++)
{
    int idade = Convert.ToInt32(Console.ReadLine());
    idades[iCount] = idade;
    somaIdades += idade;

    if (iCount == 0)
    {
        menor = idade;
        maior = idade;
    }

    if (idade > maior)
    {
        maior = idade;
    }
    if (idade < menor)
    {
        menor = idade;
    }
}

double media = somaIdades / idades.Length;
Console.WriteLine($"Média: {media:f2} | Menor: {menor} | Maior: {maior}");