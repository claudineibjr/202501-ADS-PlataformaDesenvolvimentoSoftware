// 7. Incremente o programa anterior exibindo a média com 2 casas decimais. (nível 2)

double num1 = Convert.ToDouble(Console.ReadLine());
double num2 = Convert.ToDouble(Console.ReadLine());

double resultado = (num1 + num2) / 2;

Console.WriteLine($"{resultado:f2}");