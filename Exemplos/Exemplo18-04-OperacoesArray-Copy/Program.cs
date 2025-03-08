string[] nomes = { "Vitor Roque", "Paulinho", "Estevão" };

string[] nomes2 = new string[5];

Array.Copy(nomes, nomes2, nomes.Length);

foreach(string nome in nomes2)
{
    Console.WriteLine(nome);
}