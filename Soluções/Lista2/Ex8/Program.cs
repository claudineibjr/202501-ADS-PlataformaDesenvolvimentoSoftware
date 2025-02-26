const int notaAprovacao = 7;
const int notaMinima = 4;
const int notaAprovacaoExame = 5;

// Leitura dos dados
float nota1 = float.Parse(Console.ReadLine());
float nota2 = float.Parse(Console.ReadLine());

// Cálculo
float media = (nota1 + nota2) / 2;

// Exibição
if (media >= notaAprovacao) {
  Console.WriteLine($"{media:f2} - Aprovado");
} else if (media >= notaMinima) {
  Console.WriteLine($"{media:f2} - Exame");
} else {
  Console.WriteLine($"{media:f2} - Reprovado");
}

// Sub ou exame
if (media < notaAprovacao) {
  string opcaoSub = Console.ReadLine();

  if (opcaoSub == "S") {
    // Leitura da nota da sub
    float notaSub = float.Parse(Console.ReadLine());

    // Identifica a menor nota e a substitui pela nota da sub    
    if (nota1 > nota2) {
      media = (nota1 + notaSub) / 2;
    } else {
      media = (nota2 + notaSub) / 2;
    }

    // Exibição
    if (media >= notaAprovacao) {
      Console.WriteLine($"{media:f2} - Aprovado");
    } else if (media >= notaMinima) {
      Console.WriteLine($"{media:f2} - Exame");
    } else {
      Console.WriteLine($"{media:f2} - Reprovado");
    }
  }

  // Verifica se vai para exame
  if (media >= notaMinima && media < notaAprovacao) {
    float notaExame = float.Parse(Console.ReadLine());

    media = (media + notaExame) / 2;
    if (media >= notaAprovacaoExame) {
      Console.WriteLine($"{media:f2} - Aprovado");
    } else {
      Console.WriteLine($"{media:f2} - Reprovado");
    }
  }
}