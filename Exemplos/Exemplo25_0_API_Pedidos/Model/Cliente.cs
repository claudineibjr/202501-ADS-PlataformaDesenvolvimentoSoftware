using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exemplo25_0_API_Pedidos.Model
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }

        public Cliente(string nome, string email, string senha, string cpf)
        {
            this.Nome = nome;
            this.Email = email;
            this.CPF = cpf;
        }

        private Cliente()
        {
            
        }
    }
}
