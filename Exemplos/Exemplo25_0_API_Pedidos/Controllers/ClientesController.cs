using Exemplo25_0_API_Pedidos.Database;
using Exemplo25_0_API_Pedidos.DTO;
using Exemplo25_0_API_Pedidos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo25_0_API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly PedidosDbContext dbContext;

        public ClientesController(PedidosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTOOutput>> GetClientes()
        {
            IEnumerable<ClienteDTOOutput> clientes = dbContext
                .Clientes
                .Select(
                    c => new ClienteDTOOutput(c.Id, c.Nome, c.Email, c.CPF )
                );

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTOOutput> GetCliente(string id)
        {
            Cliente? cliente = dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (cliente is null)
            {
                return NotFound();
            }

            ClienteDTOOutput clienteDTO = new ClienteDTOOutput(cliente.Id, cliente.Nome, cliente.Email, cliente.CPF);

            return Ok(clienteDTO);
        }

        [HttpPost]
        public ActionResult<Cliente> CreateCliente(ClienteDTOInput novoClienteDTO)
        {
            if (dbContext.Clientes.Any(cliente => cliente.CPF.Equals(novoClienteDTO.CPF)))
            {
                return BadRequest("Já existe um cliente com este CPF");
            }

            Cliente novoCliente = new Cliente(novoClienteDTO.Nome, novoClienteDTO.Email, novoClienteDTO.Senha, novoClienteDTO.CPF);

            dbContext.Clientes.Add(novoCliente);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(CreateCliente), novoCliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(string id, ClienteDTOInput clienteAAtualizarDTO)
        {
            Cliente? clienteEncontrado =
                dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (clienteEncontrado == null)
            {
                return NotFound();
            }

            if (dbContext.Clientes.Any(cliente => cliente.Id != id && cliente.CPF.Equals(clienteAAtualizarDTO.CPF)))
            {
                return BadRequest("Já existe um cliente com este CPF");
            }

            clienteEncontrado.Nome = clienteAAtualizarDTO.Nome;
            clienteEncontrado.Email = clienteAAtualizarDTO.Email;
            clienteEncontrado.Senha = clienteAAtualizarDTO.Senha;
            clienteEncontrado.CPF = clienteAAtualizarDTO.CPF;

            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(string id)
        {
            Cliente? clienteEncontrado =
                dbContext
                .Clientes
                .FirstOrDefault(p => p.Id == id);

            if (clienteEncontrado == null)
            {
                return NotFound();
            }

            dbContext.Clientes.Remove(clienteEncontrado);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
