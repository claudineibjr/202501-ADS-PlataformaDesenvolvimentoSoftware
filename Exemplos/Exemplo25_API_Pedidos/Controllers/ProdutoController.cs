using Exemplo25_API_Pedidos.Database;
using Exemplo25_API_Pedidos.DTO;
using Exemplo25_API_Pedidos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo25_API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

      private PedidosManagerDbContext dbContext;

      public ProdutoController(PedidosManagerDbContext dbContext) {
        this.dbContext = dbContext;
      }

      [HttpGet]
      public ActionResult<IEnumerable<Produto>> GetProdutos([FromQuery] string? nome) {
        IQueryable<Produto> produtos = 
          dbContext
          .Produtos
          .AsQueryable();

        if (!String.IsNullOrEmpty(nome)) {
          produtos = produtos
            .Where(
              produto => produto.Nome.ToUpper().Contains(nome.ToUpper())
            );
        }

        produtos = produtos.OrderBy(produto => produto.Nome);

        return Ok(produtos);
      }

      [HttpGet("id")]
      public ActionResult<IEnumerable<Produto>> GetProduto(string id) {
        Produto? produto = 
          dbContext
          .Produtos
          .FirstOrDefault(produto => produto.Id == id);

        if (produto == null) {
          return NotFound();
        }

        return Ok(produto);
      }

      [HttpPost]
      public ActionResult<Produto> CreateProduto(ProdutoDTO produtoDTO) {
        if (!ModelState.IsValid) {
          return BadRequest();
        }

        Produto novoProduto = new Produto(produtoDTO.Nome, produtoDTO.Preco);

        dbContext.Produtos.Add(novoProduto);
        dbContext.SaveChanges();

        return CreatedAtAction(nameof(CreateProduto), novoProduto);
      }
      
      [HttpPut("id")]
      public IActionResult UpdateProduto(string id, ProdutoDTO produtoDTO) {
        if (!ModelState.IsValid) {
          return BadRequest();
        }

        Produto? produto = 
          dbContext
          .Produtos
          .FirstOrDefault(produto => produto.Id == id);

        if (produto == null) {
          return NotFound();
        }

        produto.Nome = produtoDTO.Nome;
        produto.Preco = produtoDTO.Preco;

        dbContext.SaveChanges();

        return NoContent();
      }

      [HttpDelete("id")]
      public IActionResult DeleteProduto(string id) {
        Produto? produto = 
          dbContext
          .Produtos
          .FirstOrDefault(produto => produto.Id == id);

        if (produto == null) {
          return NotFound();
        }

        dbContext.Produtos.Remove(produto);
        dbContext.SaveChanges();

        return NoContent();
      }
    }
}
