const string empresa = "Sociedade Analista Desenvolvedora LTDA";

string visitante = Console.ReadLine();

string mensagem = $@"Olá {visitante}.
Nós da {empresa} estamos felizes com sua visita!

Atenciosamente,
{empresa}";

Console.WriteLine(mensagem);