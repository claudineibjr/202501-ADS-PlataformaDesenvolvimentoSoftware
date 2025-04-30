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

  static IEnumerable<Produto> GetProdutos() {
    IEnumerable<Produto> produtosOrdenadosPorNome = db.Produtos.OrderBy(p => p.Nome);

    return produtosOrdenadosPorNome;
  }

  static void ListarProdutos(bool exibirTitulo = true) {
    if (exibirTitulo) {
      Console.WriteLine("Produtos: ");
    }
    
    IEnumerable<Produto> produtos = GetProdutos();    

    for (int iCount = 0; iCount < produtos.Count(); iCount++) {
      Produto produto = produtos.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {produto.Nome} {produto.Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
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

  static IEnumerable<Cliente> GetClientes() {
    return db.Clientes.OrderBy(p => p.Nome);
  }

  static void ListarClientes(bool exibirTitulo = true) {
    if (exibirTitulo) {
      Console.WriteLine("Clientes: ");
    }

    IEnumerable<Cliente> clientes = GetClientes();
    for (int iCount = 0; iCount < clientes.Count(); iCount++) {
      Cliente cliente = clientes.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {cliente.Nome} {cliente.CPF}");
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

  static Cliente SelecionarCliente() {
    Console.WriteLine("Selecione o cliente");
    ListarClientes(exibirTitulo: false);

    Console.Write("Cliente selecionado: ");
    int indiceSelecionado = Convert.ToInt32(Console.ReadLine());

    Cliente cliente = GetClientes().ElementAt(indiceSelecionado - 1);

    return cliente;
  }

  static List<Produto> SelecionarProdutos() {
    List<Produto> produtosSelecionados = new List<Produto>();

    int indiceSelecionado = 0;

    do {
      Console.WriteLine("Selecione os produtos");
      ListarProdutos(exibirTitulo: false);
      Console.WriteLine("0 - Terminar seleção");

      Console.Write("Produto selecionado: ");
      indiceSelecionado = Convert.ToInt32(Console.ReadLine());

      if (indiceSelecionado > 0) {
        Produto produto = GetProdutos().ElementAt(indiceSelecionado - 1);

        produtosSelecionados.Add(produto);
      }
    } while (indiceSelecionado > 0);

    return produtosSelecionados;
  }

  static void CadastrarPedido() {
    Console.WriteLine("Cadastro de pedido: ");

    Cliente cliente = SelecionarCliente();

    List<Produto> produtos = SelecionarProdutos();

    Pedido pedido = new Pedido(cliente, produtos);

    db.Pedidos.Add(pedido);
    db.SaveChanges();
  }

  static void ListarPedidos() {
    Console.WriteLine("Pedidos: ");

    IEnumerable<Pedido> pedidosOrdenadosPorData = db.Pedidos.OrderByDescending(p => p.Data);

    for (int iCount = 0; iCount < pedidosOrdenadosPorData.Count(); iCount++) {
      Pedido pedido = pedidosOrdenadosPorData.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {pedido.Cliente.Nome} {pedido.ValorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
    }
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
          CadastrarPedido();
          break;

        case "2":
          ListarPedidos();
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
