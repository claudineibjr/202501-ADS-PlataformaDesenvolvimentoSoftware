using System.Text;

string[] nomes = { "Vitor Roque", "Paulinho", "Estevão" };

string ataque = "";
foreach (string nome in nomes)
{
    ataque = $"{ataque}{nome}";
}

// Com string builder
StringBuilder ataqueStringBuilder = new StringBuilder();
foreach (string nome in nomes)
{
    ataqueStringBuilder.AppendLine(nome);
}

Console.WriteLine(ataqueStringBuilder.ToString());