namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PessoasDbContext db = new PessoasDbContext();

            Console.WriteLine("Pessoas: ");
            foreach(Pessoa pessoa in db.Pessoas.ToList())
            {
                Console.WriteLine($"{pessoa.Nome} ({pessoa.Idade})");
            }
        }
    }
}
