namespace Ex05
{
    internal class Program
    {
        /*
            5. (Contagem de vogais com funções) Implemente um programa que conte quantas vezes cada uma
            das vogais aparecem em uma determinada frase. Para isso, crie uma função que recebe a
            frase a verificar e a letra a verificar, e então devolva o número de vezes que aquela letra aparece na frase.
         */

        static int ContaLetra(string palavra, char letraAContar)
        {
            int contador = 0;
            foreach (char letra in palavra)
            {
                if (letra == letraAContar)
                {
                    contador++;
                }
            }

            return contador;
        }

        static void Main(string[] args)
        {
            string palavra = Console.ReadLine();

            int letrasA = ContaLetra(palavra, 'A');
            int letrasE = ContaLetra(palavra, 'E');
            int letrasI = ContaLetra(palavra, 'I');
            int letrasO = ContaLetra(palavra, 'O');
            int letrasU = ContaLetra(palavra, 'U');

            Console.WriteLine($"A: {letrasA}");
            Console.WriteLine($"E: {letrasE}");
            Console.WriteLine($"I: {letrasI}");
            Console.WriteLine($"O: {letrasO}");
            Console.WriteLine($"U: {letrasU}");


        }
    }
}
