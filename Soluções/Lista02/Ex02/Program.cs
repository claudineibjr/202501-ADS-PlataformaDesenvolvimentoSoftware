// Leitura dos dados
int num1 = Convert.ToInt32(Console.ReadLine());
string operador = Console.ReadLine();
int num2 = Convert.ToInt32(Console.ReadLine());

double resultado;

// Identificação do operador e exibição
switch(operador)
{
    case "+": 
        resultado = num1 + num2;
        Console.WriteLine(resultado);
        break;

    case "-":
        resultado = num1 - num2;
        Console.WriteLine(resultado);
        break;

    case "*":
        resultado = num1 * num2;
        Console.WriteLine(resultado);
        break;

    case "/":
        resultado = num1 / num2;
        Console.WriteLine(resultado);
        break;
}