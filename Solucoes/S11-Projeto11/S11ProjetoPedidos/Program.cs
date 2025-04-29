using System.Globalization;

namespace S11ProjetoPedidos;

public class Program
{

  static PedidosManagerDbContext db = new PedidosManagerDbContext();

  static void CadastrarProduto() {
    Console.WriteLine("Cadastro de produto: ");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Preço: ");
    decimal preco = Convert.ToDecimal(Console.ReadLine());

    Produto novoProduto = new Produto(nome, preco);

    db.Produtos.Add(novoProduto);
    db.SaveChanges();
  }

  static void ListarProdutos() {
    Console.WriteLine("Produtos: ");

    foreach (Produto produto in db.Produtos.OrderBy(p => p.Nome)) {
      Console.WriteLine($"{produto.Nome} {produto.Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
    }
  }

  static void MenuProduto() {
    string opcao = "0";

    string menu = @"
  Menu Produtos
    1 - Cadastrar
    2 - Listar
    0 - Sair";

    do
    {
      Console.WriteLine(menu);
      opcao = Console.ReadLine();

      switch (opcao)
      {
        case "1":
          CadastrarProduto();
          break;

        case "2":
          ListarProdutos();
          break;
      }

    } while (opcao != "0");
  }

  public static void Main(string[] args) {
    string opcao = "0";

    string menu = @"
Menu Principal
  1 - Produto
  0 - Sair";

    do
    {
      Console.WriteLine(menu);
      opcao = Console.ReadLine();

      switch (opcao)
      {
        case "1":
          MenuProduto();
          break;
      }

    } while (opcao != "0");
  }
}
