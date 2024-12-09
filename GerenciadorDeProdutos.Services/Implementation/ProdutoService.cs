using GerenciadorDeProdutos.Domain.Data;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Repository.Interfaces;
using GerenciadorDeProdutos.Services.Interfaces;
using GerenciadorDeProdutos.Services.Request;
using GerenciadorDeProdutos.Services.Response;

namespace GerenciadorDeProdutos.Services.Implementation
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.ObterTodos();
        }

        public async Task<IEnumerable<Produto>> ObterTodosEmEstoque()
        {
            return await _produtoRepository.ObterTodosEmEstoque();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        public async Task<AdicionarProdutoResponse> Adicionar(AdicionarProdutoRequest request)
        {
            var produto = new Produto(request.Nome, request.Descricao, request.Status, request.Preco, request.QuantidadeEstoque, request.CategoriaId);
            ValidarProduto(produto);

            await _produtoRepository.Adicionar(produto);
            return new AdicionarProdutoResponse();
        }

        private static void ValidarProduto(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new ArgumentException("Nome do produto não pode estar vazio.");

            if (!CategoriaData.Categorias.Any(c => c.Id == produto.CategoriaId))
                throw new ArgumentException("Categoria não permitida para o produto.");
            
            if(produto.QuantidadeEstoque < 1)
                throw new ArgumentException("Não é permitido cadastrado produto sem estoque");

            if (produto.Preco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");
        }

        public async Task<AtualizarProdutoResponse> Atualizar(AtualizarProdutoRequest request)
        {
            var produto = new Produto(request.Id, request.Nome, request.Descricao, request.Status, request.Preco, request.QuantidadeEstoque, request.CategoriaId);
            ValidarProduto(produto);
            await _produtoRepository.Atualizar(produto);
            return new AtualizarProdutoResponse();
        }

        public async Task Excluir(int id)
        {
            await _produtoRepository.Excluir(id);
        }
    }
}
