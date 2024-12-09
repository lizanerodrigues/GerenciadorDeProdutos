using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Repository.Interfaces;
public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodos();
    Task<IEnumerable<Produto>> ObterTodosEmEstoque();
    Task<Produto> ObterPorId(int id);
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Excluir(int id);
}
