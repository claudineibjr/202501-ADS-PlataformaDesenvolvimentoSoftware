using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatDS_Sub.Model;

public class Filme
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Key]
  public string Titulo { get; set; }
  public string Descricao { get; set; }
  public int Ano { get; set; }
  public string Id { get; set; }
  public decimal Arrecadacao { get; set; }
  public float NotaIMDB { get; set; }
  public List<string> Atores { get; set; }

  public Filme(string Titulo, string Descricao, int Ano, decimal Arrecadacao, float NotaIMDB, List<string> Atores)
  {
    this.Titulo = Titulo;
    this.Descricao = Descricao;
    this.Ano = Ano;
    this.Arrecadacao = Ano;
    this.NotaIMDB = Ano;
    this.Atores = Atores;
  }

  private Filme() {}
}
