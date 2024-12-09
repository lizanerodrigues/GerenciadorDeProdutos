using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Data
{
    public static class CategoriaData
    {
        public static List<Categoria> Categorias { get; } = new List<Categoria>
        {
            new Categoria { Id = 1, Nome = "Eletrônicos" },
            new Categoria { Id = 2, Nome = "Eletrodomésticos" },
            new Categoria { Id = 3, Nome = "Móveis" },
            new Categoria { Id = 4, Nome = "Brinquedos" },
            new Categoria { Id = 5, Nome = "Ferramentas" },
            new Categoria { Id = 6, Nome = "Roupas" },
            new Categoria { Id = 7, Nome = "Calçados" }
        };
    }
}
