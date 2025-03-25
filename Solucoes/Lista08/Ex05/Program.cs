namespace Ex05
{
    internal class Program
    {
        /*
            5. (Lista de alunos) Incremente o Exercício 4. 4. (Lista de alunos).
            Após a exibição do nome dos alunos, leia um texto (nome inteiro ou
            parcial) a ser removido, e então, percorra toda a lista de alunos
            removendo os alunos que contenham aquele nome
         */
        static void Main(string[] args)
        {
            List<string> nomes = new List<string>();

            string novoNome = "";

            do
            {
                Console.Write("Digite o nome: ");
                novoNome = Console.ReadLine();
                if (novoNome != "" && !nomes.Contains(novoNome))
                {
                    nomes.Add(novoNome);
                }
            } while (novoNome != "");

            Console.Write("Digite o nome a remover: ");
            string nomeARemover = Console.ReadLine();
            nomes.Remove(nomeARemover);

            nomes.Sort();

            foreach (string nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }
    }
}
