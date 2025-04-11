using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Emprego
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public string Id {get; set;}
    public string Empresa { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Emprego(string Empresa, string Cargo, decimal Salario) {
      this.Empresa = Empresa;
      this.Cargo = Cargo;
      this.Salario = Salario;
    }

    private Emprego() { }
}