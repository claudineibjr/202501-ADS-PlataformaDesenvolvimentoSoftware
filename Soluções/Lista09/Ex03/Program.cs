namespace Ex03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a quantidade em estoque: ");
            int estoque = Convert.ToInt32(Console.ReadLine());

            Produto produto = new Produto(nome, preco, estoque);
            Console.WriteLine(produto.ExibirInformacoes());
        }
    }
}
