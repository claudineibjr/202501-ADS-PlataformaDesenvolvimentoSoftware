// Escreva um programa que receba do usuário o nome de um produto, o valor e a quantidade.
// No final, o programa deve exibir o valor total da compra e também o nome do produto. (nível 3)

string produto = Console.ReadLine();
decimal valor = Convert.ToDecimal(Console.ReadLine());
int quantidade = Convert.ToInt32(Console.ReadLine());

decimal valorTotal = valor * quantidade;

string mensagem = @$"Total: R$ {valorTotal:f2}
- {quantidade}x {produto}";

Console.WriteLine(mensagem);