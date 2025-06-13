using System;

namespace PlatDS_Sub.DTO;

public class FilmeDTOInput
{
  public string titulo { get; set; }
  public string descricao { get; set; }
  public int ano { get; set; }
  public decimal arrecadacao { get; set; }
  public float notaIMDB { get; set; }
  public List<string> atores { get; set; }
}

public class FilmeDTOOutput
{
  public string id { get; set; }
  public string titulo { get; set; }
  public int ano { get; set; }
  public decimal arrecadacao { get; set; }
  public float notaIMDB { get; set; }
}
