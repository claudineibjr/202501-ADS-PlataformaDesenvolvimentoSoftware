using Exemplo25_0_API_Pedidos.Database;
using Exemplo25_0_API_Pedidos.DTO;
using Exemplo25_0_API_Pedidos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace Exemplo25_0_API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext dbContext;

        public PedidosController(PedidosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Pedido> CreatePedido(PedidoDTO novoPedidoDTO)
        {
            if (novoPedidoDTO.ProdutosIds.Length == 0)
            {
                return BadRequest("É necessário enviar a lista de produtos");
            }

            List<Produto> produtos = dbContext
                .Produtos
                .Where(
                    produto => novoPedidoDTO.ProdutosIds.Contains(produto.Id)
                ).ToList();

            if (produtos.Count != novoPedidoDTO.ProdutosIds.Length)
            {
                return BadRequest("Produto não encontrado");
            }

            Cliente? cliente = dbContext
                .Clientes
                .Find(novoPedidoDTO.ClienteId);

            if (cliente is null)
            {
                return BadRequest("Cliente não encontrado");
            }

            Pedido novoPedido = new Pedido(produtos, cliente, DateTime.Now);

            dbContext.Pedidos.Add(novoPedido);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreatePedido), novoPedido);
        }

    }
}
