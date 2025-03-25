namespace Ex01
{
    internal class Program
    {
        static double Soma(double num1, double num2)
        {
            double resultado = num1 + num2;
            return resultado;
        }

        static double Subtracao(double num1, double num2)
        {
            double resultado = num1 - num2;
            return resultado;
        }

        static double Multiplicacao(double num1, double num2)
        {
            double resultado = num1 * num2;
            return resultado;
        }

        static double Divisao(double num1, double num2)
        {
            double resultado = num1 / num2;
            return resultado;
        }

        static double Calculadora(string operador, double num1, double num2)
        {
            switch(operador)
            {
                case "+":
                    return Soma(num1, num2);

                case "-":
                    return Subtracao(num1, num2);

                case "*":
                    return Multiplicacao(num1, num2);

                case "/":
                    return Divisao(num1, num2);

                default:
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Operador: ");
            string operador = Console.ReadLine();

            Console.Write("Número 1: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Número 2: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double resultado = Calculadora(operador, num1, num2);
            Console.Write($"Resultado: {resultado}");
        }
    }
}
