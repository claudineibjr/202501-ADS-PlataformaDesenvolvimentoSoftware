Console.Write("Digite o número de alunos: ");
int numAlunos = Convert.ToInt32(Console.ReadLine());

string[] alunos = new string[numAlunos];

for (int iCount = 0; iCount < alunos.Length; iCount++)
{
    Console.Write($"Digite o nome do {iCount + 1}º aluno: ");
    string nomeAluno = Console.ReadLine();
    alunos[iCount] = nomeAluno;
}

Console.WriteLine("Alunos");
for (int iCount = 0; iCount < alunos.Length; iCount++)
{
    Console.WriteLine($"Nome: {alunos[iCount]}");
}