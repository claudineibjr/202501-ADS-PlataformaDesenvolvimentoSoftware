// 8. Incremente o programa anterior de forma que antes de receber as notas, o programa deve receber o peso de cada uma das notas para calcular a média final. A soma dos pesos deve ser 100. (nível 2)

double peso1 = Convert.ToDouble(Console.ReadLine());
double peso2 = Convert.ToDouble(Console.ReadLine());

double num1 = Convert.ToDouble(Console.ReadLine());
double num2 = Convert.ToDouble(Console.ReadLine());

double resultado = (peso1 / 100 * num1) + (peso2 / 100 * num2);

Console.WriteLine($"{resultado:f2}");