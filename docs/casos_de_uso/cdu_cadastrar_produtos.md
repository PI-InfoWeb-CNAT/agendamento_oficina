# Projeto Agendamento de Serviços

## Especificação do caso de uso - Cadastrar Produtos 

### Histórico da Revisão 

|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 02/12/2021 | **1.00** | Versão Inicial  | Rafael Ribeiro |

### 1. Resumo 

Nesse caso de uso, o usuário funcionário acessa o sistema e cadastra um determinado produto, informando sua marca, descrição, quantidade e categoria.

### 2. Atores 

Funcionário

### 3. Pré-condições

O funcionário deve ter vericado o estoque para saber a quantidade e disponibilidade do produto.

### 4. Pós-condições

O sistema recebe um novo produto em seu banco de dados.

### 5. Fluxos de Evento

O usuário mecânico acessa a tela de produtos, e ao clicar em "CADASTRAR NOVO PRODUTO", informa os dados e adiciona o mesmo.

#### 5.1. Fluxo Básico

| Ator   | Sistema |
|:-------|:--------|
| 1. O funcionário seleciona um produto para ser cadastrado no sistema. ||
|| 2. O sistema lista os produtos já cadastrados, permitindo inserir novos produtos, como também remover e detalhar os produtos já existentes. |

#### 5.2. Fluxos de Exceção

| Exceção | Sistema |
|:--------|:--------|
| 1. Dados inválidos para a operação | Se o funcionário tentar inserir um produto inválido ou ja existente no banco de dados, o sistema deve apresentar um alerta e não realizar a operação. |
| 2. Cpf já cadastrado | Se o usuário tentar realizar um novo cadastro, informando um cpf já cadastro na base de dados, o sistema deve apresentar um alerta e não realizar a operação. |


### 6. Protótipos de Interface

