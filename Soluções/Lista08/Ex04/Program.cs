namespace Ex04
{
    internal class Program
    {
        /*
            4. (Lista de alunos) Implemente um programa que crie uma lista e
            armazene o nome dos alunos de uma sala. Não devem ser inseridos
            nomes repetidos. O programa deve ler o nome de alunos até que o
            nome do aluno seja vazio. No final, exiba a lista de alunos de forma
            ordenada.
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

            nomes.Sort();

            foreach(string nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }
    }
}
