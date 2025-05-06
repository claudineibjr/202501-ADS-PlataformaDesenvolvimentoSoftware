using Exemplo25_API_Pedidos.Database;
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
    }
}
