# Projeto Agendamento de Serviços

## Especificação do caso de uso - Cadastrar Clientes 

### Histórico da Revisão 

|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 02/12/2021 | **1.00** | Versão Inicial  | Rafael Ribeiro |

### 1. Resumo 

Nesse caso de uso, o usuário cliente acessa o sistema e se cadastra, informando seu nome, cpf, endereço e E-mail, além da criação de sua senha.

### 2. Atores 

Cliente

### 3. Pré-condições

O cliente deve acessar o site e não possuir cpf cadastrado na base dados.

### 4. Pós-condições

O sistema recebe um novo cliente em seu banco de dados.

### 5. Fluxos de Evento

O usuário cliente entra na página do site, e ao clicar em LOGIN ou em FAÇA SEU AGENDAMENTO, ele terá a opção de realizar seu cadastro, caso ainda não possua o mesmo.

#### 5.1. Fluxo Básico

| Ator   | Sistema |
|:-------|:--------|
| 1. O cliente acessa o site para efetuar seu cadastro. ||
|| 2. O sistema verifica as informações, e caso nenhum erro seja apresentado, efetua o cadastro do cliente. |

#### 5.2. Fluxos de Exceção

| Exceção | Sistema |
|:--------|:--------|
| 1. Dados inválidos para a operação | Se o cliente inserir algum dado pessoal inválido, o sistema deve apresentar um alerta e não realizar a operação. |  

### 6. Protótipos de Interface

