using Exemplo25_0_API_Pedidos.Database;
using Exemplo25_0_API_Pedidos.DTO;
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
        public ActionResult<Produto> CreateProduto(ProdutoDTO novoProdutoDTO)
        {
            Produto novoProduto = new Produto(novoProdutoDTO.nome, novoProdutoDTO.preco, novoProdutoDTO.imagemUrl);

            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreateProduto), novoProduto);
        }

        [HttpPost("{id}/Upload")]
        public async Task<ActionResult<Produto>> UploadImage(string id, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                return BadRequest("No image found");
            }

            Produto? produto = dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produto is null)
            {
                return NotFound();
            }

            string extensaoArquivo = arquivo.FileName.Substring(arquivo.FileName.LastIndexOf(".") + 1);

            string nomePasta = "produtos";
            string caminhoDaPastaDeUploads = Path.Combine("wwwroot", nomePasta);
            Directory.CreateDirectory(caminhoDaPastaDeUploads);

            string nomeDoArquivo = $"{id}.{extensaoArquivo}";
            string caminhoDoArquivo = Path.Combine(caminhoDaPastaDeUploads, nomeDoArquivo);

            using (var stream = new FileStream(caminhoDoArquivo, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            string urlServidor = $"{Request.Scheme}:{Request.Host}";
            
            string imagemUrl = $"{urlServidor}/{nomePasta}/{nomeDoArquivo}";

            produto.ImagemURL = imagemUrl;
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(UploadImage), produto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduto(string id, ProdutoDTO produtoAAtualizarDTO)
        {
            Produto? produtoEncontrado =
                dbContext
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produtoEncontrado == null)
            {
                return NotFound();
            }

            produtoEncontrado.Nome = produtoAAtualizarDTO.nome;
            produtoEncontrado.Preco = produtoAAtualizarDTO.preco;
            produtoEncontrado.ImagemURL = produtoAAtualizarDTO.imagemUrl;

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
