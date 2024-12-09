using GerenciadorDeProdutos.Domain.Data;
using GerenciadorDeProdutos.Domain.Enums;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Repository.Implementation;
public class ProdutoRepository : IProdutoRepository
{
    private readonly GerenciadorDeProdutosContext context;

    public ProdutoRepository(GerenciadorDeProdutosContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        var produtos = await context.Produtos.ToListAsync();

        foreach (var produto in produtos)
        {
            produto.Categoria = CategoriaData.Categorias.FirstOrDefault(c => c.Id == produto.CategoriaId);
        }

        return produtos;
    }

    public async Task<IEnumerable<Produto>> ObterTodosEmEstoque()
    {
        var produtos = await context.Produtos.Where(p => p.Status == StatusEnum.EmEstoque).Include(p => p.Categoria).ToListAsync();

        foreach (var produto in produtos)
        {
            produto.Categoria = CategoriaData.Categorias.FirstOrDefault(c => c.Id == produto.CategoriaId);
        }

        return produtos;
    }

    public async Task<Produto> ObterPorId(int id)
    {
        var produto = await context.Produtos.FindAsync(id);
        produto.Categoria = CategoriaData.Categorias.FirstOrDefault(c => c.Id == produto.CategoriaId);
        return produto;
    }

    public async Task Adicionar(Produto produto)
    {
        context.Produtos.Add(produto);
        await context.SaveChangesAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        context.Produtos.Update(produto);
        await context.SaveChangesAsync();
    }

    public async Task Excluir(int id)
    {
        var produto = await context.Produtos.FindAsync(id);
        if (produto != null)
        {
            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();
        }
    }
}
