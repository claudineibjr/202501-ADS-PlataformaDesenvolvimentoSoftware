// Incremente o programa anterior, de forma que sejam 3 produtos e 
// seja exibido o valor total e também o total por produto. (nível 3)

// Produto 1
string produto1 = Console.ReadLine();
decimal valor1 = Convert.ToDecimal(Console.ReadLine());
int quantidade1 = Convert.ToInt32(Console.ReadLine());

decimal valorTotal1 = valor1 * quantidade1;

// Produto 2
string produto2 = Console.ReadLine();
decimal valor2 = Convert.ToDecimal(Console.ReadLine());
int quantidade2 = Convert.ToInt32(Console.ReadLine());

decimal valorTotal2 = valor2 * quantidade2;

// Produto 3
string produto3 = Console.ReadLine();
decimal valor3 = Convert.ToDecimal(Console.ReadLine());
int quantidade3 = Convert.ToInt32(Console.ReadLine());

decimal valorTotal3 = valor3 * quantidade3;

// Final
decimal valorFinal = valorTotal1 + valorTotal2 + valorTotal3;

string mensagem = @$"Total: R$ {valorFinal:f2}
 - {quantidade1}x {produto1} - R$ {valorTotal1:f2}
 - {quantidade2}x {produto2} - R$ {valorTotal2:f2}
 - {quantidade3}x {produto3} - R$ {valorTotal3:f2}";

Console.WriteLine(mensagem);