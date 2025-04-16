using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp8
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }

        private Pessoa()
        {            }
    }
}
