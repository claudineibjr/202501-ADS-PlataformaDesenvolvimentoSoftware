using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ConsoleApp8
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }

        public Pessoa(string nome, int idade, string email, string profissao)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Email = email;
            this.Profissao = profissao;
        }

        private Pessoa()
        {            }
    }
}
