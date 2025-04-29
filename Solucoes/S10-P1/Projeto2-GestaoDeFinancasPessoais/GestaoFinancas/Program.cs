namespace GestaoFinancas;

class Program
{
  static void Main(string[] args)
  {
    string opcao = "0";

    string menu = @"
1 - Cadastrar nova conta
2 - Cadastrar despesa
3 - Cadastrar receita
4.1 - Exibir o saldo total
4.2 - Exibir o saldo por conta
5.1 - Listar transações
5.2 - Listar receitas
5.3 - Listar despesas
6.1 - Listar transações por mês
6.2 - Listar receitas por mês
6.3 - Listar despesas por mês
0 - Sair";

    do
    {
      Console.WriteLine(menu);
      opcao = Console.ReadLine();

      switch (opcao)
      {
        // Implementação
      }

    } while (opcao != "0");
  }
}
