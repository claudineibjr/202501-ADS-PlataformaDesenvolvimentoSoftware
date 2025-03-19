namespace Ex07
{
    internal class Program
    {
        /*
         * 7. (Sorteio de alunos) Implemente um programa que leia o número de
            alunos que o usuário quer inserir no array, depois disso, leia o nome de
            cada um dos alunos, e então, sorteie um aluno entre todos os alunos
            incluídos.
            Para submissão no Skurge, leia do usuário a semente para a aleatoriedade.
            Ordem dos dados de entrada: Semente para aleatoriedade / Quantidade de alunos /
            Nome do Aluno N…*

         */
        static void Main(string[] args)
        {
            int quantidadeAlunos = Convert.ToInt32(Console.ReadLine());

            string[] alunos = new string[quantidadeAlunos];

            for (int iCount = 0; iCount < alunos.Length; iCount++)
            {
                alunos[iCount] = Console.ReadLine();
            }

            Random rnd = new Random();
            if (quantidadeAlunos > 0)
            {
                int indiceSorteado = rnd.Next(0, quantidadeAlunos);

                string alunoSorteado = alunos[indiceSorteado];
                Console.Write(alunoSorteado);
            }
        }
    }
}
