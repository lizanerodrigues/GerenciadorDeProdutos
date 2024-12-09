using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Services.Request;
using GerenciadorDeProdutos.Services.Response;

namespace GerenciadorDeProdutos.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<IEnumerable<Produto>> ObterTodosEmEstoque();
        Task<Produto> ObterPorId(int id);
        Task<AdicionarProdutoResponse> Adicionar(AdicionarProdutoRequest request);
        Task<AtualizarProdutoResponse> Atualizar(AtualizarProdutoRequest request);
        Task Excluir(int id);
    }
}
