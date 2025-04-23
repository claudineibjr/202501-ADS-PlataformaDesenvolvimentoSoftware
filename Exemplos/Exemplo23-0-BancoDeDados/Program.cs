using Microsoft.EntityFrameworkCore;

namespace ConsoleApp8
{
    internal class Program
    {

        static PessoasDbContext db = new PessoasDbContext();

        static void ExibirPessoas(int idadeMinima)
        {
            Console.WriteLine("Pessoas: ");
            IEnumerable<Pessoa> pessoasOrdenadasPorIdade = db.Pessoas
                .OrderByDescending(p => p.Idade)
                .Where(p => p.Idade >= idadeMinima)
                .Include(p => p.Endereco);

            foreach (Pessoa pessoa in pessoasOrdenadasPorIdade)
            {
                Console.WriteLine($"{pessoa.Nome} - " +
                    $"{pessoa.Idade} anos - " +
                    $"Profissão: {pessoa.Profissao} - " +
                    $"Email: {pessoa.Email} - " +
                    $"Endereço: {pessoa.Endereco.Logradouro}, " +
                    $"{pessoa.Endereco.Numero} - {pessoa.Endereco.Cidade}");
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

            Endereco novoEndereco = CriarEndereco();

            Pessoa novaPessoa = new Pessoa(nome, idade, email, profissao, novoEndereco);

            db.Pessoas.Add(novaPessoa);
            db.SaveChanges();
        }

        static Endereco CriarEndereco()
        {
            Console.Write("Digite a cidade: ");
            string cidade = Console.ReadLine();

            Console.Write("Digite o logradouro: ");
            string logradouro = Console.ReadLine();

            Console.Write("Digite o número: ");
            string numero = Console.ReadLine();

            return new Endereco(logradouro, numero, cidade);
        }

        static void Main(string[] args)
        {
            // CriarPessoa();
            ExibirPessoas(0);
        }
    }
}
