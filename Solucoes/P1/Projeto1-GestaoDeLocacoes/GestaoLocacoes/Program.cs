namespace GestaoLocacoes;

class Program
{
  static void Main(string[] args)
  {
    string opcao = "0";

    string menu = @"
1 - Cadastrar novo filme
2 - Cadastrar novo cliente
3 - Locar filme
4 - Devolver filme
5.1 - Listar todos os filmes
5.2 - Listar filmes disponíveis
5.3 - Listar filmes indisponíveis
6 - Listar clientes
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
