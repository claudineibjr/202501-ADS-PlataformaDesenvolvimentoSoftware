const int notaAprovacao = 7;
const int notaMinima = 4;

float nota1 = float.Parse(Console.ReadLine());
float nota2 = float.Parse(Console.ReadLine());

float media = (nota1 + nota2) / 2;

if (media >= notaAprovacao) {
  Console.WriteLine($"{media:f2} - Aprovado");
} else if (media >= notaMinima) {
  Console.WriteLine($"{media:f2} - Exame");
} else {
  Console.WriteLine($"{media:f2} - Reprovado");
}