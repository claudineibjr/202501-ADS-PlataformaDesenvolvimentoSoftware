namespace GestaoTarefas;

class Program
{
  static void Main(string[] args)
  {
    string opcao = "0";

    string menu = @"
1 - Cadastrar novo responsável
2 - Cadastrar tarefa
3 - Excluir tarefa
4 - Atualizar status da tarefa
5.1 - Listar tarefas
5.2 - Listar tarefas pendentes
5.3 - Listar tarefas concluídas
6.1 - Listar tarefas por responsável
6.2 - Listar tarefas pendentes por responsável
6.3 - Listar tarefas concluídas por responsável
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
