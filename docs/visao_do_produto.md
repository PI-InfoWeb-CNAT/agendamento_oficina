# Documento de Visão

## Sistema de Agendamento de Serviços

### Histórico da Revisão 

|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 02/09/2021 |  **`1.02`** | Versão inicial  | Gabriel Guilherme |


### 1. Objetivo do Projeto 

O projeto __Oficina do Márcio__ tem como objetivo prover uma solução simples, acessível e padronizada para o agendamento de serviços mecânicos através da Internet.

### 2. Descrição do Problema 

|         __        | __   |
|:------------------|:-----|
| **_O problema_**    | Marcar um horário de atendimento com mecânico de forma simples enviando um relato do problema identificado no veículo. |
| **_afetando_**      | Profissionais, mecânicos e empresas, como a Oficina do Márcio, que fornecem serviços de manutenção de veículos à sociedade e pessoas que precisam contratar esses serviços, agendando um horário de atendimento. |
| **_cujo impacto é_**| Dificuldade no atendimento, dificuldade na contratação dos serviços, perda de clientes (empresas e profissionais) e não realização de serviços para clientes por conta da falta de organização do tempo. |
| **_uma boa solução seria_** | Um sistema na Internet que permita a Oficina do Márcio informar os tipos de serviços realizados pela empresa, a disponibilidade de horários de atendimento, facilitando o agendamento para seus clientes. E para os clientes, um sistema que facilite o agendamento de um atendimento e/ou orçamento para um determinado serviço no seu veículo. |

### 3. Descrição dos Usuários

| Nome | Descrição | Responsabilidades |
|:---  |:--- |:--- |
| Administrador  | Realiza as atividades básicas para o início e manutenção da operação do sistema | Mantém o cadastro dos funcionários responsáveis pela operação da agenda de serviços e gerencia o funcionamento do sistema |
| Funcionário | Realiza as atividades referentes aos agendamentos, orçamentos e realização dos serviços | Mantém o cadastro de serviços, mantém o cadastro de produtos usados na manutenção dos veículos; mantém o cadastro dos clientes e veículos; mantém a agenda de atendimento; registra os serviços realizados, totalizando o custo do serviço, incluindo mão-de-obra e produtos  |
| Cliente | Agenda os atendimentos informando um pré-diagnóstico dos problemas | Realiza o próprio cadastro no sistema; consulta a agenda de serviços para verificar a disponibilidade de horários de atendimento; agenda os seus serviços; consulta e cancela um agendamento; consulta os serviços já realizados |

### 4. Descrição do Ambiente dos Usuários

Em várias atividades do cotidiano humano é necessário agendar um horário determinado para que uma ação específica seja realizada. Isso ocorre, por exemplo, quando um automóvel vai ser revisado em uma oficina, quando um médico vai consultar um paciente ou quando consertos diversos (hidráulicos, elétricos, dentre outros) são realizados em uma residência. 

Em muitas dessas situações, o cliente precisa atualmente estabelecer um contato pessoal com o profissional ou com a empresa prestadora do serviço para agendar um atendimento. E, como isso é normalmente realizado por telefone ou aplicativo de mensagens, encontrar um horário de atendimento possível para ambas as partes pode ser custoso, pois há a necessidade de encontrar um horário viável para os dois envolvidos.

Desta forma, a ideia central do sistema é permitir que empresas e profissionais registrem suas disponibilidades de atendimento e que clientes, em geral, possam consultar e agendar horários para realização e contratação de serviços. Com isso, o sistema pode estabelecer um canal de comunicação mais ágil entre clientes e empresas ou profissionais.

### 5. Principais Necessidades dos Usuários

Para empresas e profissionais, a necessidade é divulgar sua disponibilidade de atendimentos para viabilizar, de forma mais eficiente, o atendimento dos seus clientes.

Para os clientes, as necessidades são encontrar profissionais e empresas prestadoras de serviço e agendar atendimentos com estes de acordo as disponibilidades de tempo dos envolvidos.

### 6.	Alternativas Concorrentes

As alternativas concorrentes são, em geral, específicas para uma empresa ou profissional. A ideia do sistema proposto é prover uma solução simples, acessível e padronizada para o agendamento de serviços e que pode ser utilizada por quaisquer profissionais e empresas.

### 7.	Visão Geral do Produto

Em resumo, o sistema Oficina do Márcio é uma aplicação que permite a empresa de mecânica registrar suas disponibilidades de atendimento aos seus clientes, de forma que estes possam consultar e agendar horários para realização de serviços e orçamento de seus veículos.

O sistema deve ter uma interface amigável e permitir o acesso concorrente de clientes para agendamento de um horário de atendimento de forma simples.

### 8. Requisitos Funcionais

| Código | Nome | Descrição |
|:---  |:--- |:--- |
| **RF01** | Entrar no sistema | Usuários devem logar no sistema usando uma chave única para acessar as funcionalidades relacionadas ao agendamento |
| **RF02** | Cadastro de Funcionários | Administrador do sistema mantém o cadastro dos funcionários responsáveis pelo gerenciamento das agendas e prestação de serviços |
| **RF03** | Gerenciamento de Serviços | Funcionário mantém a relação de serviços prestados pela Oficina do Márcio |
| **RF04** | Gerenciamento da Agenda | Funcionário registra os horários disponíveis de atendimento, confirma e cancela o agendamento de clientes |
| **RF05** | Cadastro de Clientes | Cliente deve realizar o auto cadastramento |
| **RF06** | Consulta de Agendas | Cliente consulta agendas de atendimento dos serviços disponíveis, podendo agendar um serviço em um horário compatível |
| **RF07** | Consulta de Agendamento | Cliente consulta atendimentos agendados, podendo cancelar um agendamento |
| **RF08** | Recuperação de senha do usuário | Usuário solicita recuperação de senha, enviando uma mensagem para seu e-mail |


### 9. Requisitos Não-funcionais

 Código | Nome | Descrição | Categoria | Classificação
|:---  |:--- |:--- |:--- |:--- |
| RNF01 | Design responsivo | O sistema deve adaptar-se a qualquer tamanho de tela de dispositivo, seja, computador, tablets ou smart phones. | Usabilidade | Obrigatório |
| RNF02 | Criptografia de dados | Senhas de usuários e informações delicadas devem ser gravadas de forma criptografada no banco de dados. | Segurança | Obrigatório |
| RNF03 | Controle de acesso | Só usuários autenticados podem ter acesso ao sistema, seja um funcionário autorizado no lado do funcionário, e assim também para o cliente | Segurança | Obrigatório |
| RNF04 | Tempo de resposta | A comunicação entre o servidor e o cliente deve ocorrer em tempo hábil | Performance | Desejável |
| RNF05 | Sistema Web | A aplicação deve ser um site. | Arquitetura | Obrigatório |
| RNF06 | Dados pessoais | Os clientes não devem visualizar dados de outros clientes, apenas a disponibilidade (na agenda, por exemplo). | Privacidade | Obrigatório |
