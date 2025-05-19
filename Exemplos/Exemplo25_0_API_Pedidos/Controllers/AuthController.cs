using Exemplo25_0_API_Pedidos.Database;
using Exemplo25_0_API_Pedidos.DTO;
using Exemplo25_0_API_Pedidos.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Exemplo25_0_API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly PedidosDbContext dbContext;

        public AuthController(PedidosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private string GenerateToken(Cliente cliente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, cliente.Nome),
                    new Claim(ClaimTypes.Email, cliente.Email),
                    new Claim("id", cliente.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        [HttpGet("me")]
        public ActionResult<Cliente> Me()
        {
            Claim? clienteId = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (clienteId is null)
            {
                throw new UnauthorizedAccessException();
            }

            Cliente? cliente = dbContext.Clientes.Find(clienteId.Value);
            if (cliente is null)
            {
                throw new UnauthorizedAccessException();
            }

            return cliente;
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public ActionResult<string> SignIn(SignInDTO parametros)
        {
            Cliente? cliente = dbContext
                .Clientes
                .FirstOrDefault(
                    cliente => cliente.Email == parametros.Email && cliente.Senha == parametros.Senha
                );
            
            if (cliente is null)
            {
                return NotFound();
            }

            return GenerateToken(cliente);
        }
    }
}
