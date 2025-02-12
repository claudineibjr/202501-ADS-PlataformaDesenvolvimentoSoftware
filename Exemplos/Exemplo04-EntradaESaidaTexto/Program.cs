Console.Write("Nome: ");
string nome = Console.ReadLine();

Console.WriteLine($"Seja bem-vindo, {nome}");

Console.Write("Seu ano de nascimento: ");
int anoNascimento = Convert.ToInt32(Console.ReadLine());

int idade = 2025 - anoNascimento;

Console.WriteLine($"Que legal {nome}, você completa(ou) {idade} anos nesse ano de 2025");