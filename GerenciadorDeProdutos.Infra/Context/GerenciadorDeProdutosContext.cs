using GerenciadorDeProdutos.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class GerenciadorDeProdutosContext : DbContext
{
    public GerenciadorDeProdutosContext(DbContextOptions<GerenciadorDeProdutosContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}
