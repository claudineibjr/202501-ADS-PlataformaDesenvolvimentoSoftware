namespace ConsoleApp8
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }

        public Pessoa(string nome, int idade, string email)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Email = email;
        }
    }
}
