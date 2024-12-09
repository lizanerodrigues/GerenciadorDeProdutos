using GerenciadorDeProdutos.Services.Interfaces;
using GerenciadorDeProdutos.Services.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _produtoService.ObterTodos());
        }

        [AllowAnonymous]
        [HttpGet("estoque")]
        public async Task<IActionResult> Estoque()
        {
            return Ok(await _produtoService.ObterTodosEmEstoque());
        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarProdutoRequest request)
        {
            var result = await _produtoService.Adicionar(request);
            return Ok(result);
        }

        [Authorize(Roles = "Gerente,Funcionario")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarProdutoRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var result = await _produtoService.Atualizar(request);
            return Ok(result);
        }

        [Authorize(Roles = "Gerente")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir (int id)
        {
            await _produtoService.Excluir(id);
            return NoContent();
        }
    }
}
