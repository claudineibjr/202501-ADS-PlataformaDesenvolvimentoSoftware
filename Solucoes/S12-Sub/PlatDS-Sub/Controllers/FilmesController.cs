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
    public ActionResult<IEnumerable<FilmeDTOOutput>> GetFilmes()
    {
      IEnumerable<FilmeDTOOutput> filmes = _dbContext.Filmes.Select(
        (filme) => new FilmeDTOOutput()
        {
          id = filme.Id,
          titulo = filme.Titulo,
          ano = filme.Ano,
          arrecadacao = filme.Arrecadacao,
          notaIMDB = filme.NotaIMDB
        }
      );

      return Ok(filmes);
    }

    [HttpGet("{id}")]
    public ActionResult<Filme> GetFilme(string id)
    {
      Filme? filme = _dbContext
          .Filmes
          .FirstOrDefault(p => p.Id == id);

      if (filme is null)
      {
        return NotFound();
      }

      return Ok(filme);
    }

    [HttpPost]
    public ActionResult<Filme> CreateFilme(FilmeDTOInput novoFilme)
    {
      if (novoFilme.atores.Count == 0)
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
        return NotFound();
      }

      filmeEncontrado.Titulo = novoFilme.titulo;
      filmeEncontrado.Descricao = novoFilme.descricao;
      filmeEncontrado.Ano = novoFilme.ano;
      filmeEncontrado.Arrecadacao = novoFilme.arrecadacao;
      filmeEncontrado.NotaIMDB = novoFilme.notaIMDB;

      filmeEncontrado.Atores.Clear();
      filmeEncontrado.Atores.AddRange(novoFilme.atores);
      
      _dbContext.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(string id)
    {
      Filme? filmeEncontrado =
          _dbContext
          .Filmes
          .FirstOrDefault(p => p.Id == id);

      if (filmeEncontrado == null)
      {
        return NotFound();
      }

      _dbContext.Filmes.Remove(filmeEncontrado);
      _dbContext.SaveChanges();

      return NoContent();
    }
  }
}
