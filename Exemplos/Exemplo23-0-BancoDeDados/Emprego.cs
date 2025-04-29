using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo230BancoDeDados
{
    public class Emprego
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string Profissao { get; set; }
        public decimal Salario { get; set; }

        public Emprego(string profissao, decimal salario)
        {
            this.Profissao = profissao;
            this.Salario = salario;
        }

        private Emprego() { }
    }
}
