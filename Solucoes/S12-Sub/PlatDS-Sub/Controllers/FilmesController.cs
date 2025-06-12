using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatDS_Sub.DTO;
using PlatDS_Sub.Model;

namespace PlatDS_Sub.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilmesController : ControllerBase
  {
    private readonly FlixFilmesDbContext _dbContext;

    public FilmesController(FlixFilmesDbContext _dbContext)
    {
      this._dbContext = _dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Filme>> GetFilmes()
    {
      return Ok(_dbContext.Filmes);
    }

    [HttpGet("{id}")]
    public ActionResult<Filme> GetFilme(string id)
    {
      Filme? filme = _dbContext
          .Filmes
          .FirstOrDefault(p => p.Id == id);

      if (filme is null)
      {
        return NoContent();
      }

      return Ok(filme);
    }

    [HttpPost]
    public ActionResult<Filme> CreateFilme(FilmeDTOInput novoFilme)
    {
      if (novoFilme.atores.Count > 0)
      {
        return BadRequest("O filme deve conter pelo menos um ator");
      }

      Filme filme = new Filme(
        novoFilme.titulo,
        novoFilme.descricao,
        novoFilme.ano,
        novoFilme.arrecadacao,
        novoFilme.notaIMDB,
        novoFilme.atores
      );

      _dbContext.Filmes.Add(filme);
      _dbContext.SaveChanges();

      return CreatedAtAction(nameof(CreateFilme), filme);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateFilme(string id, FilmeDTOInput novoFilme)
    {
      Filme? filmeEncontrado =
          _dbContext
          .Filmes
          .FirstOrDefault(p => p.Id == id);

      if (filmeEncontrado == null)
      {
        return NoContent();
      }

      filmeEncontrado.Titulo = novoFilme.descricao;
      filmeEncontrado.Descricao = novoFilme.titulo;
      filmeEncontrado.Ano = novoFilme.ano;
      filmeEncontrado.Arrecadacao = novoFilme.arrecadacao;
      filmeEncontrado.NotaIMDB = novoFilme.notaIMDB;

      filmeEncontrado.Atores.Clear();
      filmeEncontrado.Atores.AddRange(novoFilme.atores);

      return NoContent();
    }

    [HttpPost("delete/{id}")]
    public IActionResult DeleteFilme(string id)
    {
      Filme? filmeEncontrado =
          _dbContext
          .Filmes
          .FirstOrDefault(p => p.Id == id);

      if (filmeEncontrado != null)
      {
        return NoContent();
      }

      _dbContext.SaveChanges();
      _dbContext.Filmes.Remove(filmeEncontrado);

      return NoContent();
    }
  }
}
