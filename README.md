
# Gerenciador de Produtos - API

Este sistema permite o gerenciamento de produtos, com funcionalidades para visualizar, adicionar, atualizar e excluir produtos. A API utiliza autenticação baseada em JWT e controle de permissões baseado em roles de usuários.

## Funcionalidades da API

### 1. **Obter Todos os Produtos**
- **Método**: `GET`
- **Rota**: `/api/produtos`
- **Descrição**: Retorna todos os produtos cadastrados no sistema.
- **Permissão**: Nenhuma, acesso público.

#### Exemplo de Resposta:

```json
[
  {
    "id": 1,
    "nome": "Smartphone",
    "descricao": "Smartphone moderno",
    "status": "Ativo",
    "preco": 2500.00,
    "quantidadeEstoque": 50,
    "categoria": {
      "id": 1,
      "nome": "Eletrônicos"
    }
  },
  ...
]
```

### 2. **Obter Produtos em Estoque**
- **Método**: `GET`
- **Rota**: `/api/produtos/estoque`
- **Descrição**: Retorna apenas os produtos que estão disponíveis em estoque.
- **Permissão**: Nenhuma, acesso público.

#### Exemplo de Resposta:

```json
[
  {
    "id": 1,
    "nome": "Smartphone",
    "descricao": "Smartphone moderno",
    "status": "Ativo",
    "preco": 2500.00,
    "quantidadeEstoque": 50,
    "categoria": {
      "id": 1,
      "nome": "Eletrônicos"
    }
  }
]
```

### 3. **Adicionar Novo Produto**
- **Método**: `POST`
- **Rota**: `/api/produtos`
- **Descrição**: Permite adicionar um novo produto ao sistema.
- **Permissão**: Apenas para usuários com a role `Gerente` ou `Funcionario`.

#### Corpo da Requisição:

```json
{
  "nome": "Televisão",
  "descricao": "Televisão LED 50"",
  "status": "Ativo",
  "preco": 3500.00,
  "quantidadeEstoque": 30,
  "categoriaId": 1
}
```

#### Exemplo de Resposta:

```json
{
  "id": 1,
  "nome": "Televisão",
  "descricao": "Televisão LED 50"",
  "status": "Ativo",
  "preco": 3500.00,
  "quantidadeEstoque": 30,
  "categoria": {
    "id": 1,
    "nome": "Eletrônicos"
  }
}
```

### 4. **Atualizar Produto**
- **Método**: `PUT`
- **Rota**: `/api/produtos/{id}`
- **Descrição**: Permite atualizar as informações de um produto existente.
- **Permissão**: Apenas para usuários com a role `Gerente` ou `Funcionario`.

#### Corpo da Requisição:

```json
{
  "id": 1,
  "nome": "Televisão 4K",
  "descricao": "Televisão LED 50" 4K",
  "status": "Ativo",
  "preco": 4000.00,
  "quantidadeEstoque": 25,
  "categoriaId": 1
}
```

#### Exemplo de Resposta:

```json
{
  "id": 1,
  "nome": "Televisão 4K",
  "descricao": "Televisão LED 50" 4K",
  "status": "Ativo",
  "preco": 4000.00,
  "quantidadeEstoque": 25,
  "categoria": {
    "id": 1,
    "nome": "Eletrônicos"
  }
}
```

### 5. **Excluir Produto**
- **Método**: `DELETE`
- **Rota**: `/api/produtos/{id}`
- **Descrição**: Permite excluir um produto do sistema.
- **Permissão**: Apenas para usuários com a role `Gerente`.

#### Exemplo de Resposta:

```json
{}
```

## Autenticação e Autorização

A API utiliza autenticação baseada em **JWT** (JSON Web Tokens). Para acessar os endpoints que requerem autenticação, você precisará incluir o token JWT no cabeçalho da requisição.

- **Cabeçalho**: `Authorization: Bearer <token_jwt>`
  
### Roles de Usuários

- **Gerente**: Pode adicionar, atualizar e excluir produtos.
- **Funcionário**: Pode adicionar e atualizar produtos.
- **Cliente**: Pode visualizar produtos, mas não tem permissões para adicionar, atualizar ou excluir produtos.

## Usuários de Exemplo

Os seguintes usuários estão pré-configurados para teste:

- **Gerente**
  - **Usuário**: `gerente`
  - **Senha**: `123456`
  - **Role**: `Gerente`
  
- **Funcionário**
  - **Usuário**: `funcionario`
  - **Senha**: `123456`
  - **Role**: `Funcionario`
  
- **Cliente**
  - **Usuário**: `cliente`
  - **Senha**: `123456`
  - **Role**: `Cliente`
