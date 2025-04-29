using System.Globalization;
using System.Security.Cryptography;

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

static void CadastrarCliente() {
    Console.WriteLine("Cadastro de cliente: ");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    bool existeClienteComMesmoCPF = db.Clientes.Any(cliente => cliente.CPF.ToUpper() == cpf.ToUpper());
    if (existeClienteComMesmoCPF) {
      throw new Exception($"Já existe um cliente com este CPF {cpf}");
    }

    Cliente novoCliente = new Cliente(nome, cpf);

    db.Clientes.Add(novoCliente);
    db.SaveChanges();
  }

  static void ListarClientes() {
    Console.WriteLine("Clientes: ");

    foreach (Cliente cliente in db.Clientes.OrderBy(p => p.Nome)) {
      Console.WriteLine($"{cliente.Nome} {cliente.CPF}");
    }
  }

  static void MenuCliente() {
    string opcao = "0";

    string menu = @"
  Menu Clientes
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
        try {
          CadastrarCliente();
        } catch (Exception ex) {
          Console.WriteLine($"Erro ao cadastrar cliente\n{ex.Message}");
        }
          break;

        case "2":
          ListarClientes();
          break;
      }

    } while (opcao != "0");
  }

  public static void Main(string[] args) {
    string opcao = "0";

    string menu = @"
Menu Principal
  1 - Produtos
  2 - Clientes
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

        case "2":
          MenuCliente();
          break;
      }

    } while (opcao != "0");
  }
}
