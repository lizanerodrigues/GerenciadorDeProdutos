﻿using GerenciadorDeProdutos.Domain.Enums;

namespace GerenciadorDeProdutos.Services.Request
{
    public class AtualizarProdutoRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public int CategoriaId { get; set; }
    }
}
