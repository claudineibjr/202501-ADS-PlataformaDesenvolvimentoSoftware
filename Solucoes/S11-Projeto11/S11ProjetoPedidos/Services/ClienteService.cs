using System;
using S11ProjetoPedidos.Services;
using S11ProjetoPedidos.Model;

namespace S11ProjetoPedidos.Services;

public class ClienteService
{
  public static void CadastrarCliente() {
    Console.WriteLine("Cadastro de cliente: ");

    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("CPF: ");
    string cpf = Console.ReadLine();

    bool existeClienteComMesmoCPF = DatabaseService.db.Clientes.Any(cliente => cliente.CPF.ToUpper() == cpf.ToUpper());
    if (existeClienteComMesmoCPF) {
      throw new Exception($"Já existe um cliente com este CPF {cpf}");
    }

    Cliente novoCliente = new Cliente(nome, cpf);

    DatabaseService.db.Clientes.Add(novoCliente);
    DatabaseService.db.SaveChanges();
  }

  public static IEnumerable<Cliente> GetClientes(string? nomeClienteABuscar = null) {
    IQueryable<Cliente> clientes = DatabaseService
      .db
      .Clientes.AsQueryable();

    if (nomeClienteABuscar != null) {
      clientes = clientes
        .Where(
          cliente => cliente.Nome.ToUpper().Contains(nomeClienteABuscar.ToUpper())
        );
    }

    return clientes.OrderBy(p => p.Nome);
  }

  public static void PesquisarClientes() {
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    ListarClientes(nomeClienteABuscar: nome);
  }

  public static void ListarClientes(bool exibirTitulo = true, string? nomeClienteABuscar = null) {
    if (exibirTitulo) {
      Console.WriteLine("Clientes: ");
    }

    IEnumerable<Cliente> clientes = GetClientes(nomeClienteABuscar);
    for (int iCount = 0; iCount < clientes.Count(); iCount++) {
      Cliente cliente = clientes.ElementAt(iCount);

      Console.WriteLine($"{iCount + 1} - {cliente.Nome} {cliente.CPF}");
    }
  }
}
