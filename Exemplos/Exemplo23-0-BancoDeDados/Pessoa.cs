using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exemplo230BancoDeDados
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public Emprego? Emprego { get; set; }

        public Pessoa(string nome, int idade, string email, string endereco, Emprego emprego)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Email = email;
            this.Endereco = endereco;
            this.Emprego = emprego;
        }

        private Pessoa() { }
    }
}
