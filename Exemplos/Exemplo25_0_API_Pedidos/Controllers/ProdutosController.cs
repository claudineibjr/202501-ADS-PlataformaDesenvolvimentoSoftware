using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Produto>> GetProduto(string id)
        {
            Produto? produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto is null) {
              return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> CreateProduto(Produto novoProduto)
        {
            produtos.Add(novoProduto);

            return CreatedAtAction(nameof(CreateProduto), novoProduto);
        }

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            produtos.AddRange([
              new Produto("Café", 35) { Id = "p1" },
              new Produto("Água", 12) { Id = "p2" },
              new Produto("Leite", 7) { Id = "p3" },
              new Produto("Fralda", 80) { Id = "p4" },
              new Produto("Desinfetante", 15) { Id = "p5" },
            ]);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(string id, Produto produtoAAtualizar)
        {
            Produto? produtoEncontrado =
                produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            produtoEncontrado.Nome = produtoAAtualizar.Nome;
            produtoEncontrado.Preco = produtoAAtualizar.Preco;

            return NoContent();

        }
    }
}
