int idade = 20;

bool éEmancipado = false;

bool temGrana = true;

bool temCarona = false;

if ((idade >= 18 || éEmancipado) && temGrana) {
  Console.WriteLine("Pode tirar CNH");
} else if (temCarona) {
  Console.WriteLine("Pode ir de carona");
} else {
  Console.WriteLine("Não pode tirar CNH");
}