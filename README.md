<img width="100%" src="https://github.com/AlessandroCarvalhoSantos/AlessandroCarvalhoSantos/blob/main/04%20-%20Outros/assets/img/readme/ArtBaltaDesafio.png">

# IbgeApiChallenge

## Descrição

Este desafio está focado na construção de uma API que forneça informações sobre cidades e estados do Brasil. Os aspirantes podem se basear no [repositório GitHub do balta](https://github.com/andrebaltieri/ibge), que contém dados relevantes, embora a estrutura do banco de dados possa ser diferente. O objetivo é desenvolver uma API funcional

---

## Detalhes Técnicos

- **Framework**: .NET 8 (Versão: 8.0.100-rc.2.23502.2)
- **Arquitetura**: Usando Minimal APIs
- **Banco de dados**: SQL Server!
- **Server**: Amazon EC2 (AMD4, 16gb ram, r5dn.large)
---

## Links 

[**Acessar Swagger**](http://ec2-35-173-11-131.compute-1.amazonaws.com/swagger/index.html)

[**Link API**](http://ec2-35-173-11-131.compute-1.amazonaws.com)
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
