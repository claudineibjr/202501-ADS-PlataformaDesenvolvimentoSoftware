using Exemplo25_0_API_Pedidos.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly PedidosDbContext dbContext;

        public ProdutosController(PedidosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return Ok(dbContext.Produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Produto>> GetProduto(string id)
        {
            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produto is null) {
              return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> CreateProduto(Produto novoProduto)
        {
            if (string.IsNullOrEmpty(novoProduto.Id))
            {
                novoProduto.Id = Guid.NewGuid().ToString();
            }

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreateProduto), novoProduto);
        }

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            dbContext.Produtos.AddRange([
              new Produto("Café", 35) { Id = "p1" },
              new Produto("Água", 12) { Id = "p2" },
              new Produto("Leite", 7) { Id = "p3" },
              new Produto("Fralda", 80) { Id = "p4" },
              new Produto("Desinfetante", 15) { Id = "p5" },
            ]);
            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(string id, Produto produtoAAtualizar)
        {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            produtoEncontrado.Nome = produtoAAtualizar.Nome;
            produtoEncontrado.Preco = produtoAAtualizar.Preco;
            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(string id) {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            dbContext.Produtos.Remove(produtoEncontrado);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
