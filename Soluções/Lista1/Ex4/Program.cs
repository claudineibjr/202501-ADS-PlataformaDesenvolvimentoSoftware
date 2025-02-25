// L1.4. Escreva um programa que receba dois números e calcule o percentual do primeiro número com relação ao segundo. (nível 1)

double num1 = Convert.ToDouble(Console.ReadLine());
double num2 = Convert.ToDouble(Console.ReadLine());

double resultado = num1 * 100 / num2;

Console.WriteLine($"{resultado}%");