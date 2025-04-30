using System.Globalization;
using System.Security.Cryptography;
using S11ProjetoPedidos.Model;
using S11ProjetoPedidos.Services;
using S11ProjetoPedidos.Database;

namespace S11ProjetoPedidos;

public class Program
{

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
          ProdutoService.CadastrarProduto();
          break;

        case "2":
          ProdutoService.ListarProdutos();
          break;
      }

    } while (opcao != "0");
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
          ClienteService.CadastrarCliente();
        } catch (Exception ex) {
          Console.WriteLine($"Erro ao cadastrar cliente\n{ex.Message}");
        }
          break;

        case "2":
          ClienteService.ListarClientes();
          break;
      }

    } while (opcao != "0");
  }

  static void MenuPedido() {
    string opcao = "0";

    string menu = @"
  Menu Pedidos
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
          PedidoService.CadastrarPedido();
          break;

        case "2":
          PedidoService.ListarPedidos();
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
  3 - Pedidos
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

        case "3":
          MenuPedido();
          break;
      }

    } while (opcao != "0");
  }
}
