# Projeto Agendamento de Serviços

## Especificação do caso de uso - Agendar Serviços 

### Histórico da Revisão 

|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 29/12/2021 | **1.00** | Versão Inicial  | Rafael Ribeiro |

### 1. Resumo 

Nesse caso de uso, o usuário cliente acessa o sistema e realiza um agendamento de serviço, selecionando o dia, hora, possível motivo e opcionalmente uma breve descrição.

### 3. Pré-condições

O cliente deve estar cadastrado no sistema e ter efetuado login.

### 4. Pós-condições

O sistema recebe um novo agendamento em seu banco de dados.

### 5. Fluxos de Evento

O usuário cliente acessa o site, e ao clicar em "FAÇA SEU AGENDAMENTO" e efutuar login no sistema, realiza seu agendamento.

#### 5.1. Fluxo Básico

| Ator   | Sistema |
|:-------|:--------|
| 1. O cliente acessa o site e seleciona um dia disponível para realizar o agendamento. ||
|| 2. O sistema lista os dias e horários disponíveis, permitindo selecionar de acordo com a disponibilidade do cliente. |

#### 5.2. Fluxos de Exceção

| Exceção | Sistema |
|:--------|:--------|
| 1. Horário já selecionado | Se o cliente demorar para realizar o agendamento, e o horário selecionado já estiver sido preenchido, o sistema deve apresentar um alerta e não realizar a operação. |



### 6. Protótipos de Interface


