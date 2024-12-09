using GerenciadorDeProdutos.Domain.Enums;

namespace GerenciadorDeProdutos.Domain.Models;
public class Produto
{
    public Produto(string nome, string descricao, StatusEnum status, decimal preco, decimal quantidadeEstoque, int categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        Status = status;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        CategoriaId = categoriaId;
    }

    public Produto(int id, string nome, string descricao, StatusEnum status, decimal preco, decimal quantidadeEstoque, int categoriaId)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Status = status;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        CategoriaId = categoriaId;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public StatusEnum Status { get; set; }
    public string StatusDescricao => Status.ToString();
    public decimal Preco { get; set; }
    public decimal QuantidadeEstoque { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
