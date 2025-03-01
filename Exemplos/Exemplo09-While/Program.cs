string menu = "1 - Vendas\n2 - Compras\n0 - Sair";
Console.WriteLine(menu);

int opcao = Convert.ToInt32(Console.ReadLine());

while (opcao != 0)
{
    switch(opcao)
    {
        case 1: Console.WriteLine("Vendas"); break;
        case 2: Console.WriteLine("Compras"); break;
    }

    Console.WriteLine(menu);
    opcao = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Fim!");