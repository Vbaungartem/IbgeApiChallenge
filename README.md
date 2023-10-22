# IbgeApiChallenge

## Descrição

Este projeto é um desafio API que foca na implementação de diversas funcionalidades essenciais para aplicações modernas, desde autenticação até operações CRUD relacionadas à localidades.

---

## Requisitos

Todos os projetos devem entregar as seguintes funcionalidades:

- **Autenticação e Autorização**
  - Cadastro de E-mail e Senha
  - Login com Token e JWT
  
- **CRUD de Localidade**
  - Campos: Código, Estado, Cidade (Id, City, State)
  
- **Pesquisas**
  - Por cidade
  - Por estado
  - Por código (IBGE)
  
- **Boas Práticas da API**
  - Versionamento
  - Padronização
  - Documentação com Swagger

## Classificação da Equipe

- Júnior

---

## Detalhes Técnicos

- **Framework**: .NET 8 (Versão: 8.0.100-rc.2.23502.2)
- **Arquitetura**: Usando Minimal APIs
- **Objetivo**: Entregar uma API 100% funcional!

## Checklist de Metas Realizadas

### User
- [x] CRUD
    - [x] Create
    - [x] Update
- [x] Cadastro de E-mail e Senha
- [x] Login (Token, JWT)
- [x] Atualização de senha
- [x] Autenticação e Autorização

### Locality
- [x] CRUD
    - [x] Create
    - [x] Read
    - [x] Update
    - [x] Delete
- [x] Pesquisar por nome do local
- [x] Pesquisar por nome do estado. 
- [x] Pesquisa por código (IBGE)
- [x] Autenticação e Autorização

### State
- [x] CRUD
    - [x] Create
    - [x] Read
    - [x] Update
    - [x] Delete
- [x] Pesquisar por nome do estado
- [x] Pesquisa por código (IBGE)
- [x] Autenticação e Autorização

## Esquema de Banco de Dados

### Tabelas

#### 1. auth_roles
- `id`: uniqueidentifier
- `name`: NVARCHAR(150)

#### 2. auth_users
- `Id`: uniqueidentifier
- `name`: NVARCHAR(250)
- `given_name`: NVARCHAR(250)
- `email`: NVARCHAR(250)
- `password_hash`: NVARCHAR(250)

#### 3. auth_users_x_roles
- `id_role`: uniqueidentifier
- `id_user`: uniqueidentifier

#### 4. states
- `Id`: uniqueidentifier
- `ibge_code`: NVARCHAR(250)
- `name`: NVARCHAR(250)
- `acronym`: NVARCHAR(250)

#### 5. localities
- `Id`: uniqueidentifier
- `ibge_code`: NVARCHAR(250)
- `name`: NVARCHAR(250)
- `state_id`: uniqueidentifier
