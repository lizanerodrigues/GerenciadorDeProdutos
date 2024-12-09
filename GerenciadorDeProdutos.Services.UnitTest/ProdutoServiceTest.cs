using GerenciadorDeProdutos.Domain.Enums;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Repository.Interfaces;
using GerenciadorDeProdutos.Services.Implementation;
using GerenciadorDeProdutos.Services.Request;
using GerenciadorDeProdutos.Services.Response;
using Moq;

namespace GerenciadorDeProdutos.Tests
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
        }

        [Fact]
        public async Task Adicionar_ProdutoValido_DeveAdicionarProdutoComSucesso()
        {
            // Arrange
            var request = new AdicionarProdutoRequest
            {
                Nome = "Smartphone",
                Descricao = "Smartphone moderno",
                Status = StatusEnum.EmEstoque,
                Preco = 2500.00M,
                QuantidadeEstoque = 10,
                CategoriaId = 1
            };

            // Act
            var response = await _produtoService.Adicionar(request);

            // Assert
            _produtoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Produto>()), Times.Once);
            Assert.IsType<AdicionarProdutoResponse>(response);
        }

        [Fact]
        public async Task Adicionar_ProdutoComNomeVazio_DeveLancarExcecao()
        {
            // Arrange
            var request = new AdicionarProdutoRequest
            {
                Nome = "",
                Descricao = "Smartphone moderno",
                Status = StatusEnum.EmEstoque,
                Preco = 2500.00M,
                QuantidadeEstoque = 10,
                CategoriaId = 1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _produtoService.Adicionar(request));
            Assert.Equal("Nome do produto não pode estar vazio.", exception.Message);
        }

        [Fact]
        public async Task Adicionar_ProdutoComCategoriaInvalida_DeveLancarExcecao()
        {
            // Arrange
            var request = new AdicionarProdutoRequest
            {
                Nome = "Smartphone",
                Descricao = "Smartphone moderno",
                Status = StatusEnum.EmEstoque,
                Preco = 2500.00M,
                QuantidadeEstoque = 10,
                CategoriaId = 999 // Categoria inexistente
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _produtoService.Adicionar(request));
            Assert.Equal("Categoria não permitida para o produto.", exception.Message);
        }

        [Fact]
        public async Task Adicionar_ProdutoComEstoqueMenorQue1_DeveLancarExcecao()
        {
            // Arrange
            var request = new AdicionarProdutoRequest
            {
                Nome = "Smartphone",
                Descricao = "Smartphone moderno",
                Status = StatusEnum.EmEstoque,
                Preco = 2500.00M,
                QuantidadeEstoque = 0,
                CategoriaId = 1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _produtoService.Adicionar(request));
            Assert.Equal("Não é permitido cadastrado produto sem estoque", exception.Message);
        }

        [Fact]
        public async Task Adicionar_ProdutoComPrecoZero_DeveLancarExcecao()
        {
            // Arrange
            var request = new AdicionarProdutoRequest
            {
                Nome = "Smartphone",
                Descricao = "Smartphone moderno",
                Status = StatusEnum.EmEstoque,
                Preco = 0,
                QuantidadeEstoque = 10,
                CategoriaId = 1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _produtoService.Adicionar(request));
            Assert.Equal("O preço deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public async Task Atualizar_ProdutoValido_DeveAtualizarProdutoComSucesso()
        {
            // Arrange
            var request = new AtualizarProdutoRequest
            {
                Id = 1,
                Nome = "Smartphone 4K",
                Descricao = "Smartphone com tela 4K",
                Status = StatusEnum.EmEstoque,
                Preco = 3000.00M,
                QuantidadeEstoque = 15,
                CategoriaId = 1
            };

            // Act
            var response = await _produtoService.Atualizar(request);

            // Assert
            _produtoRepositoryMock.Verify(r => r.Atualizar(It.IsAny<Produto>()), Times.Once);
            Assert.IsType<AtualizarProdutoResponse>(response);
        }

        [Fact]
        public async Task Excluir_ProdutoValido_DeveExcluirProdutoComSucesso()
        {
            // Arrange
            var produtoId = 1;

            // Act
            await _produtoService.Excluir(produtoId);

            // Assert
            _produtoRepositoryMock.Verify(r => r.Excluir(produtoId), Times.Once);
        }

    }
}
