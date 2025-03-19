namespace Ex06
{
    internal class Program
    {
        /*
         * 6. (Sorteio) Implemente um programa que gere 6 números aleatórios
            entre 1 e 20 (não devem ser incluídos números repetidos). Depois disso,
            leia um número informado pelo usuário, e então, exiba todos os
            números que foram sorteados e por último, informe se o número
            inserido pelo usuário foi sorteado.
            Crie uma função que irá criar um array de inteiros e incluir os valores
            aleatórios neste array, essa função deve receber o número de
            elementos a serem criados no array e devolver este array.
            Crie outra função que receba o array de números aleatórios, peça ao
            usuário digitar um número e devolva um bool indicando se o número
            digitado foi sorteado ou não.
            Crie outra função que irá exibir todos os elementos do array e também
            irá informar se o número do usuário foi sorteado ou não.
         */

        static int[] CriaNumerosSorteio(int quantidade)
        {

            Random rnd = new Random();

            int[] numerosSorteados = new int[quantidade];
            for (int iCount = 0; iCount < numerosSorteados.Length; iCount++)
            {
                numerosSorteados[iCount] = rnd.Next(1, 21);
            }

            return numerosSorteados;
        }

        static bool SorteioUsuario(int[] numerosSorteados)
        {
            Console.Write("Número de sorte: ");
            int numeroUsuario = Convert.ToInt32(Console.ReadLine());

            return numerosSorteados.Contains(numeroUsuario);
        }

        static void ExibeNumerosSorteados(int[] numerosSorteados, bool usuarioSorteado)
        {

            Console.WriteLine("Numeros sorteados: ");
            foreach (int numero in numerosSorteados)
            {
                Console.WriteLine(numero);
            }

            string mensagemUsuario = usuarioSorteado ? "O número do usuário foi sorteado" : "O número do usuário não foi sorteado";
            Console.WriteLine(mensagemUsuario);
        }

        static void Main(string[] args)
        {
            int[] numerosSorteados = CriaNumerosSorteio(6);
            bool usuarioSorteado = SorteioUsuario(numerosSorteados);
            ExibeNumerosSorteados(numerosSorteados, usuarioSorteado);
        }
    }
}
