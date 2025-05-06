using System;
using S11ProjetoPedidos.Model;
using S11ProjetoPedidos.Database;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace S11ProjetoPedidos.Services;

public class ProdutoService
{

  public static void CadastrarProduto() {
    Console.WriteLine("Cadastro de produto: ");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Preço: ");
    decimal preco = Convert.ToDecimal(Console.ReadLine());

    Produto novoProduto = new Produto(nome, preco);

    DatabaseService.db.Produtos.Add(novoProduto);
    DatabaseService.db.SaveChanges();
  }

  public static IEnumerable<Produto> GetProdutos(string? nomeProdutoABuscar = null) {
    IQueryable<Produto> produtos = DatabaseService
      .db
      .Produtos.AsQueryable();
    if (nomeProdutoABuscar != null) {
      produtos = produtos
        .Where(
          produto => produto.Nome.ToUpper().Contains(nomeProdutoABuscar.ToUpper())
        );
    }

    return produtos.OrderBy(produto => produto.Nome);
  }

  public static void PesquisarProdutos() {
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    ListarProdutos(nomeProdutoABuscar: nome);
  }

  public static void ListarProdutos(bool exibirTitulo = true, string? nomeProdutoABuscar = null) {
    if (exibirTitulo) {
      Console.WriteLine("Produtos: ");
    }
    
    IEnumerable<Produto> produtos = GetProdutos(nomeProdutoABuscar);

    for (int iCount = 0; iCount < produtos.Count(); iCount++) {
      Produto produto = produtos.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {produto.Nome} {produto.Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
    }
  }
}
