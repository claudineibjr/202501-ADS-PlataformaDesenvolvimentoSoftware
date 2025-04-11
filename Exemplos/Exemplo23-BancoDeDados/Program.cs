using System.Security.Cryptography.X509Certificates;
using Exemplo23_BancoDeDados;
using Microsoft.EntityFrameworkCore;

public class Program
{
  static PessoasDbContext dbContext = new PessoasDbContext();
  static DbSet<Pessoa> pessoas = dbContext.Pessoas;

  static void Main(string[] args)
  {
    

    bool sair = false;

    while (!sair)
    {
      Console.WriteLine("\n--- MENU ---");
      Console.WriteLine("1. Cadastrar pessoa");
      Console.WriteLine("2. Listar usuários (ordenado por nome)");
      Console.WriteLine("3. Listar usuários (ordenado por salário total)");
      Console.WriteLine("4. Excluir pessoa");
      Console.WriteLine("5. Criar pessoas (seed)");
      Console.WriteLine("6. Sair");
      Console.Write("Escolha uma opção: ");
      string opcao = Console.ReadLine();

      switch (opcao)
      {
        case "1":
          CadastrarPessoa();
          break;
        case "2":
          ListarPessoasPorNome();
          break;
        case "3":
          ListarPessoasPorSalario();
          break;
        case "4":
          ExcluirPessoa();
          break;
        case "5":
          Seed();
          break;
        case "6":
          sair = true;
          break;
        default:
          Console.WriteLine("Opção inválida!");
          break;
      }
    }
  }

  static void CadastrarPessoa()
  {
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Idade: ");
    int idade = int.Parse(Console.ReadLine());

    List<Emprego> empregos = new List<Emprego>();

    Console.Write("Quantos empregos a pessoa possui? ");
    int qtdEmpregos = int.Parse(Console.ReadLine());

    for (int i = 0; i < qtdEmpregos; i++)
    {
      Console.WriteLine($"Emprego {i + 1}:");
      Console.Write("Nome da Empresa: ");
      string empresa = Console.ReadLine();

      Console.Write("Cargo: ");
      string cargo = Console.ReadLine();

      Console.Write("Salário: ");
      decimal salario = decimal.Parse(Console.ReadLine());

      empregos.Add(new Emprego(empresa, cargo, salario));
    }

    Pessoa pessoa = new Pessoa(nome, idade, empregos);
    pessoas.Add(pessoa);

    dbContext.SaveChanges();

    Console.WriteLine("Pessoa cadastrada com sucesso!");
  }

  static void ListarPessoasPorNome()
  {
    Console.WriteLine("\n--- Lista de Pessoas (Ordenado por Nome) ---");

    var pessoasOrdenadasPeloNome = pessoas.ToList().OrderByDescending(p => p.Nome);

    foreach (Pessoa pessoa in pessoasOrdenadasPeloNome)
    {
      Console.WriteLine(pessoa.Info);
    }
  }

  static void ListarPessoasPorSalario()
  {
    Console.WriteLine("\n--- Lista de Pessoas (Ordenado por Salário Total) ---");

    var pessoasOrdenadasPeloSalario = pessoas.Include(p => p.Empregos).ToList().OrderByDescending(p => p.SalarioTotal);

    foreach (Pessoa pessoa in pessoasOrdenadasPeloSalario)
    {
      Console.WriteLine(pessoa.Info);
    }
  }

  static void ExcluirPessoa()
  {
    Console.WriteLine("\n--- Excluir Pessoa ---");
    Console.Write("Digite o nome da pessoa a ser excluída: ");
    string nome = Console.ReadLine();

    Pessoa pessoa = pessoas.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (pessoa != null)
    {
      pessoas.Remove(pessoa);
      Console.WriteLine("Pessoa excluída com sucesso!");
    }
    else
    {
      Console.WriteLine("Pessoa não encontrada.");
    }

    dbContext.SaveChanges();
  }

  static void Seed()
  {
    Pessoa pessoa1 = new Pessoa("Ana Clara Souza", 28, new List<Emprego>());
    Pessoa pessoa2 = new Pessoa("João Pedro Almeida", 35, new List<Emprego>());
    Pessoa pessoa3 = new Pessoa("Maria Eduarda Lima", 22, new List<Emprego>());

    Pessoa pessoa4 = new Pessoa("Lucas Gabriel Santos", 30, new List<Emprego> {
        new Emprego("Magazine Luiza", "Vendedor", 2200m)
    });

    Pessoa pessoa5 = new Pessoa("Larissa Souza Martins", 26, new List<Emprego> {
        new Emprego("Prefeitura Municipal", "Professora", 3200m)
    });

    Pessoa pessoa6 = new Pessoa("Carlos Henrique Silva", 40, new List<Emprego> {
        new Emprego("Bradesco", "Auxiliar Administrativo", 2800m)
    });

    Pessoa pessoa7 = new Pessoa("Beatriz Lima Oliveira", 24, new List<Emprego> {
        new Emprego("Rede D'Or", "Recepcionista", 2500m)
    });

    Pessoa pessoa8 = new Pessoa("Felipe Almeida Costa", 38, new List<Emprego> {
        new Emprego("Petrobras", "Motorista", 4500m),
        new Emprego("Gol Linhas Aéreas", "Atendente de Aeroporto", 3200m)
    });

    Pessoa pessoa9 = new Pessoa("Camila Rocha Pereira", 32, new List<Emprego> {
        new Emprego("Itaú", "Operador de Caixa", 3000m),
        new Emprego("Natura", "Consultora de Vendas", 2500m)
    });

    Pessoa pessoa10 = new Pessoa("Gabriel Silva Menezes", 29, new List<Emprego> {
        new Emprego("Ambev", "Analista de Sistemas", 5200m),
        new Emprego("Magazine Luiza", "Gerente de Loja", 4500m),
        new Emprego("Prefeitura Municipal", "Professor de Informática", 4000m)
    });

    pessoas.Add(pessoa1);
    pessoas.Add(pessoa2);
    pessoas.Add(pessoa3);
    pessoas.Add(pessoa4);
    pessoas.Add(pessoa5);
    pessoas.Add(pessoa6);
    pessoas.Add(pessoa7);
    pessoas.Add(pessoa8);
    pessoas.Add(pessoa9);
    pessoas.Add(pessoa10);

    dbContext.SaveChanges();
  }
}