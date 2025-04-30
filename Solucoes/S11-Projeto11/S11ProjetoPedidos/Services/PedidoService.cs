using System;
using S11ProjetoPedidos.Services;
using S11ProjetoPedidos.Model;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace S11ProjetoPedidos.Services;

public class PedidoService
{
  static Cliente SelecionarCliente() {
    Console.WriteLine("Selecione o cliente");
    ClienteService.ListarClientes(exibirTitulo: false);

    Console.Write("Cliente selecionado: ");
    int indiceSelecionado = Convert.ToInt32(Console.ReadLine());

    Cliente cliente = ClienteService.GetClientes().ElementAt(indiceSelecionado - 1);

    return cliente;
  }

  static List<Produto> SelecionarProdutos() {
    List<Produto> produtosSelecionados = new List<Produto>();

    int indiceSelecionado = 0;

    do {
      Console.WriteLine("Selecione os produtos");
      ProdutoService.ListarProdutos(exibirTitulo: false);
      Console.WriteLine("0 - Terminar seleção");

      Console.Write("Produto selecionado: ");
      indiceSelecionado = Convert.ToInt32(Console.ReadLine());

      if (indiceSelecionado > 0) {
        Produto produto = ProdutoService.GetProdutos().ElementAt(indiceSelecionado - 1);

        produtosSelecionados.Add(produto);
      }
    } while (indiceSelecionado > 0);

    return produtosSelecionados;
  }

  public static void CadastrarPedido() {
    Console.WriteLine("Cadastro de pedido: ");

    Cliente cliente = SelecionarCliente();

    List<Produto> produtos = SelecionarProdutos();

    Pedido pedido = new Pedido(cliente, produtos);

    DatabaseService.db.Pedidos.Add(pedido);
    DatabaseService.db.SaveChanges();
  }

  public static void ListarPedidos() {
    Console.WriteLine("Pedidos: ");

    IEnumerable<Pedido> pedidosOrdenadosPorData = DatabaseService.db.Pedidos
      .Include(pedido => pedido.Produtos)
      .Include(pedido => pedido.Cliente)
      .OrderByDescending(p => p.Data);

    for (int iCount = 0; iCount < pedidosOrdenadosPorData.Count(); iCount++) {
      Pedido pedido = pedidosOrdenadosPorData.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {pedido.Cliente.Nome} {pedido.ValorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))} ({pedido.Data.ToString(CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat)})");
    }
  }
}
