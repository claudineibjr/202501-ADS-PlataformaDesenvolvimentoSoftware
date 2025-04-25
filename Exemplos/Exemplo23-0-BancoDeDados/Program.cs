namespace ConsoleApp8
{
    internal class Program
    {

        static List<Pessoa> pessoas = new List<Pessoa>();

        static void ExibirPessoas(int idadeMinima)
        {
            Console.WriteLine("Pessoas: ");
            IEnumerable<Pessoa> pessoasOrdenadasPorIdade = pessoas
                .OrderByDescending(p => p.Idade)
                .Where(p => p.Idade >= idadeMinima);

            foreach (Pessoa pessoa in pessoasOrdenadasPorIdade)
            {
                Console.WriteLine($"{pessoa.Nome} - " +
                    $"{pessoa.Idade} anos - " +
                    $"Profissão: {pessoa.Profissao} - " +
                    $"Email: {pessoa.Email} - ");
            }
        }

        static void CriarPessoa()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            Console.Write("Digite a profissão: ");
            string profissao = Console.ReadLine();

            Pessoa novaPessoa = new Pessoa(nome, idade, email, profissao);

            pessoas.Add(novaPessoa);
        }
        static void Main(string[] args)
        {
            CriarPessoa();
            ExibirPessoas(0);
        }
    }
}
