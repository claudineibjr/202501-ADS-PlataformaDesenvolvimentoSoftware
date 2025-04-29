namespace Exemplo230BancoDeDados
{
    internal class Program
    {

        static PessoasDbContext db = new PessoasDbContext();

        static void ExibirPessoas(int idadeMinima)
        {
            Console.WriteLine("Pessoas: ");
            IEnumerable<Pessoa> pessoasOrdenadasPorIdade = db.Pessoas
                .OrderByDescending(p => p.Idade)
                .Where(p => p.Idade >= idadeMinima);

            foreach (Pessoa pessoa in pessoasOrdenadasPorIdade)
            {
                Console.WriteLine($"{pessoa.Nome} - " +
                    $"{pessoa.Idade} anos - " +
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

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Emprego novoEmprego = LerEmprego();

            Pessoa novaPessoa = new Pessoa(nome, idade, email, endereco, novoEmprego);

            db.Pessoas.Add(novaPessoa);
            db.SaveChanges();
        }

        static Emprego LerEmprego()
        {
            Console.Write("Digite a profissão: ");
            string profissao = Console.ReadLine();

            Console.Write("Digite o salário: ");
            decimal salario = Convert.ToDecimal(Console.ReadLine());

            return new Emprego(profissao, salario);
        }

        static void Main(string[] args)
        {
            CriarPessoa();
            ExibirPessoas(0);
        }
    }
}
