namespace Ex02
{
    internal class Carro
    {
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public Carro(string modelo, int ano)
        {
            this.Modelo = modelo;
            this.Ano = ano;
        }

        public string ObterInformacoes()
        {
            return $"{this.Modelo} ({this.Ano})";
        }
    }
}
