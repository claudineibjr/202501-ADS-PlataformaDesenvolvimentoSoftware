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
      public ActionResult<IEnumerable<Produto>> GetProdutos() {
        IQueryable<Produto> produtos = 
          dbContext
          .Produtos
          .AsQueryable();

        produtos = produtos.OrderBy(produto => produto.Nome);

        return Ok(produtos);
      }

      [HttpGet("Id")]
      public ActionResult<IEnumerable<Produto>> GetProduto(string Id) {
        Produto? produto = 
          dbContext
          .Produtos
          .FirstOrDefault(produto => produto.Id == Id);

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
    }
}
