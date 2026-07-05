# 💰 Sistema de Controle de Gastos Residenciais

API REST desenvolvida em **ASP.NET Core 8** para gerenciamento de gastos residenciais.

O sistema permite:

- Cadastro de pessoas;
- Cadastro de transações (receitas e despesas);
- Consulta de totais por pessoa;
- Consulta do total geral do sistema.

Este projeto foi desenvolvido utilizando arquitetura em camadas, seguindo boas práticas de desenvolvimento e organização do código.

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- C#
- Entity Framework Core
- MySQL
- FluentValidation
- Swagger / OpenAPI
- Middleware para tratamento global de exceções

---

# 📁 Estrutura do Projeto

```
BackEnd
│
├── src
│   ├── Controllers
│   ├── Data
│   ├── DTOs
│   ├── Entities
│   ├── Exceptions
│   ├── Interfaces
│   │     ├── Repositories
│   │     └── Services
│   ├── Middlewares
│   ├── Repositories
│   ├── Services
│   └── Validators
│
├── Migrations
├── Program.cs
├── appsettings.json
└── README.md
```

---

# 🏛 Arquitetura

O projeto segue o padrão de arquitetura em camadas.

```
Cliente

↓

Controller

↓

Validator (FluentValidation)

↓

Service

↓

Repository

↓

Entity Framework

↓

MySQL
```

Cada camada possui uma responsabilidade específica.

## Controllers

Responsáveis por receber as requisições HTTP e retornar as respostas.

Não possuem regra de negócio.

---

## Services

Responsáveis pelas regras de negócio.

Exemplos:

- verificar se uma pessoa existe;
- impedir receita para menores de idade;
- gerar relatório financeiro.

---

## Repositories

Responsáveis pelo acesso ao banco de dados utilizando Entity Framework Core.

---

## DTOs

Responsáveis pela comunicação entre cliente e API.

Evitam expor diretamente as entidades do banco.

---

## Validators

Realizam validações utilizando FluentValidation antes da requisição chegar ao Service.

---

## Middleware

Responsável pelo tratamento global das exceções da aplicação.

---

# ⚙️ Requisitos

- .NET SDK 8
- MySQL
- Visual Studio 2022 ou VS Code

---

# ▶️ Como executar

## 1 Clone o projeto

```bash
git clone https://github.com/seuusuario/seu-repositorio.git
```

---

## 2 Entre na pasta

```bash
cd BackEnd
```

---

## 3 Restaurar dependências

```bash
dotnet restore
```

---

## 4 Configurar banco de dados

No arquivo:

```
appsettings.json
```

Configure sua conexão.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=ControleGastosDB;user=root;password=123456;"
  }
}
```

---

## 5 Executar as migrations

```bash
dotnet ef database update
```

---

## 6 Executar a API

```bash
dotnet run
```

---

## 7 Abrir Swagger

```
https://localhost:xxxx/swagger
```

ou

```
http://localhost:xxxx/swagger
```

---

# 📌 Endpoints

---

## Pessoas

### Listar Pessoas

```
GET /api/pessoas
```

---

### Criar Pessoa

```
POST /api/pessoas
```

Exemplo:

```json
{
    "nome":"Geovane",
    "idade":25
}
```

Resposta:

```json
{
    "id":1,
    "nome":"Geovane",
    "idade":25
}
```

---

### Excluir Pessoa

```
DELETE /api/pessoas/{id}
```

Ao excluir uma pessoa, todas as suas transações são removidas automaticamente.

---

# Transações

---

### Listar Transações

```
GET /api/transacoes
```

---

### Criar Transação

```
POST /api/transacoes
```

Exemplo:

```json
{
    "descricao":"Salário",
    "valor":5000,
    "tipo":2,
    "pessoaId":1
}
```

### Valores do campo Tipo

| Valor | Tipo |
|--------|------|
| 1 | Despesa |
| 2 | Receita |

---

# Relatório

---

### Consultar Totais

```
GET /api/relatorio
```

Resposta:

```json
{
    "pessoas":[
        {
            "id":1,
            "nome":"Geovane",
            "totalReceitas":5000,
            "totalDespesas":1000,
            "saldo":4000
        }
    ],
    "totalReceitas":5000,
    "totalDespesas":1000,
    "saldoGeral":4000
}
```

---

# ✅ Regras de Negócio

## Pessoas

- Nome obrigatório.
- Nome entre 3 e 150 caracteres.
- Idade entre 0 e 120 anos.

---

## Transações

- Descrição obrigatória.
- Valor maior que zero.
- Pessoa deve existir.
- Apenas despesas podem ser cadastradas para menores de idade.

---

# 🔒 Tratamento de Exceções

A API utiliza um Middleware global para tratamento de erros.

Exemplo:

```json
{
    "sucesso":false,
    "mensagem":"Pessoa não encontrada.",
    "status":404
}
```

---

# ✔ Validações

Todas as validações são realizadas utilizando FluentValidation.

Exemplo:

```json
{
    "nome":"",
    "idade":-10
}
```

Resposta:

HTTP 400

---

# 🛠 Banco de Dados

Relacionamentos:

Pessoa

```
1 ---- N
```

Transações

Ao excluir uma pessoa:

- todas as transações são excluídas automaticamente (Cascade Delete).

---

# 📚 Padrões Utilizados

- Arquitetura em Camadas
- Repository Pattern
- Dependency Injection
- DTO Pattern
- Middleware
- FluentValidation
- Entity Framework Core
- REST API

---

# 📖 Fluxo da Requisição

```
Request

↓

Controller

↓

Validator

↓

Service

↓

Repository

↓

MySQL

↓

Response
```

---

# 👨‍💻 Autor

Desenvolvido por **Geovane Silva**.

GitHub:[https://github.com/GeovaneSilvaP]
