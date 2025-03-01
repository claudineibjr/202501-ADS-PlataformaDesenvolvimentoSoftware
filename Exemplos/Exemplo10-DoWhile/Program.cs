string menu = "1 - Vendas\n2 - Compras\n0 - Sair";
int opcao;

do
{
    Console.WriteLine(menu);
    opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1: Console.WriteLine("Vendas"); break;
        case 2: Console.WriteLine("Compras"); break;
    }
} while (opcao != 0);

Console.WriteLine("Fim!");