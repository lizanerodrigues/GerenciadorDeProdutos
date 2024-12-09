using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Infra.Configuration;
using GerenciadorDeProdutos.Infra.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = UserStore.Users.FirstOrDefault(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user.Username == null)
                return Unauthorized(new { message = "Credenciais inválidas." });

            var token = JwtToken.GenerateToken(user.Username, user.Role, _configuration);

            return Ok(new { token });
        }
    }
}
