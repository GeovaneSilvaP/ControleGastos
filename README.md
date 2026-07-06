# 💰 Sistema de Controle de Gastos Residenciais

Sistema fullstack para gerenciamento de gastos residenciais, composto por uma **API REST em ASP.NET Core 8** e um **frontend em React + TypeScript**.

O sistema permite:

- Cadastro de pessoas;
- Cadastro de transações (receitas e despesas);
- Consulta de totais por pessoa;
- Consulta do total geral do sistema.

Este projeto foi desenvolvido utilizando arquitetura em camadas, seguindo boas práticas de desenvolvimento e organização do código, tanto no backend quanto no frontend.

---

# 🚀 Tecnologias Utilizadas

## Backend
- ASP.NET Core 8
- C#
- Entity Framework Core
- MySQL
- FluentValidation
- Swagger / OpenAPI
- Middleware para tratamento global de exceções

## Frontend
- React
- TypeScript
- Vite
- React Router DOM
- React Hook Form
- Zod (validação de formulários)
- Axios (consumo da API)
- CSS puro (sem frameworks de UI)

---

# 📁 Estrutura do Projeto

```
ControleGastos
│
├── BackEnd
│   ├── src
│   │   ├── Controllers
│   │   ├── Data
│   │   ├── DTOs
│   │   ├── Entities
│   │   ├── Exceptions
│   │   ├── Interfaces
│   │   │     ├── Repositories
│   │   │     └── Services
│   │   ├── Middlewares
│   │   ├── Repositories
│   │   ├── Services
│   │   └── Validators
│   ├── Migrations
│   ├── Program.cs
│   ├── appsettings.json
│   └── README.md
│
└── FrontEnd
    ├── src
    │   ├── components
    │   │     ├── Button
    │   │     ├── Header
    │   │     ├── Layout
    │   │     ├── Sidebar
    │   │     └── SummaryCard
    │   ├── interfaces
    │   │     ├── CriarPessoa.ts
    │   │     ├── CriarTransacao.ts
    │   │     ├── Pessoa.ts
    │   │     ├── Relatorio.ts
    │   │     ├── RelatorioPessoa.ts
    │   │     └── Transacao.ts
    │   ├── pages
    │   │     ├── Dashboard
    │   │     ├── NovaPessoa
    │   │     ├── NovaTransacao
    │   │     ├── Pessoas
    │   │     ├── Relatorio
    │   │     └── Transacoes
    │   ├── routes
    │   │     └── AppRoutes.tsx
    │   ├── services
    │   │     ├── api.ts
    │   │     ├── pessoaService.ts
    │   │     ├── relatorioService.ts
    │   │     └── transacaoService.ts
    │   ├── App.tsx
    │   └── index.css
    └── package.json
```

---

# 🏛 Arquitetura

## Backend

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

### Controllers
Responsáveis por receber as requisições HTTP e retornar as respostas. Não possuem regra de negócio.

### Services
Responsáveis pelas regras de negócio. Exemplos:
- verificar se uma pessoa existe;
- impedir receita para menores de idade;
- gerar relatório financeiro.

### Repositories
Responsáveis pelo acesso ao banco de dados utilizando Entity Framework Core.

### DTOs
Responsáveis pela comunicação entre cliente e API. Evitam expor diretamente as entidades do banco.

### Validators
Realizam validações utilizando FluentValidation antes da requisição chegar ao Service.

### Middleware
Responsável pelo tratamento global das exceções da aplicação.

---

## Frontend

O frontend segue uma organização por responsabilidade, separando páginas, componentes reutilizáveis, serviços de comunicação com a API e tipagens.

```
Página (Pages)
   ↓
Serviço (Services / Axios)
   ↓
API (BackEnd)
```

### Pages
Componentes de página, um para cada rota da aplicação:
- **Dashboard** — exibe um resumo geral (receitas, despesas e saldo);
- **Pessoas** — lista e permite excluir pessoas cadastradas;
- **NovaPessoa** — formulário de cadastro de pessoa;
- **Transacoes** — lista as transações cadastradas;
- **NovaTransacao** — formulário de cadastro de transação;
- **Relatorio** — relatório financeiro detalhado por pessoa.

### Components
Componentes reutilizáveis de UI:
- **Layout** — estrutura base (Sidebar + Header + conteúdo da rota via `Outlet`);
- **Sidebar** — menu de navegação lateral;
- **Header** — cabeçalho fixo;
- **Button** — botão padronizado (variantes `primary` e `danger`);
- **SummaryCard** — card de resumo usado no Dashboard.

### Services
Responsáveis pela comunicação com a API, utilizando Axios:
- `api.ts` — instância do Axios configurada com a URL base da API;
- `pessoaService.ts` — listar, criar e excluir pessoas;
- `transacaoService.ts` — listar e criar transações;
- `relatorioService.ts` — obter o relatório financeiro geral.

### Interfaces
Tipagens TypeScript que espelham os DTOs do backend, garantindo tipagem forte na comunicação com a API (`Pessoa`, `CriarPessoa`, `Transacao`, `CriarTransacao`, `Relatorio`, `RelatorioPessoa`).

### Validação de Formulários
Os formulários (`NovaPessoa` e `NovaTransacao`) utilizam **React Hook Form** integrado ao **Zod** através do `@hookform/resolvers`, validando os dados no client antes de enviá-los à API.

### Rotas
As rotas são definidas em `AppRoutes.tsx` utilizando `react-router-dom`, com todas as páginas renderizadas dentro do `Layout` compartilhado (Sidebar + Header fixos).

| Rota | Página |
|------|--------|
| `/` | Dashboard |
| `/pessoas` | Pessoas |
| `/nova-pessoa` | NovaPessoa |
| `/transacoes` | Transacoes |
| `/nova-transacao` | NovaTransacao |
| `/relatorio` | Relatorio |

---

# ⚙️ Requisitos

## Backend
- .NET SDK 8
- MySQL
- Visual Studio 2022 ou VS Code

## Frontend
- Node.js 18+
- npm ou yarn

---

# ▶️ Como executar

## 1 Clone o projeto

```bash
git clone https://github.com/GeovaneSilvaP/seu-repositorio.git
```

## Backend

### 2 Entre na pasta

```bash
cd BackEnd
```

### 3 Restaurar dependências

```bash
dotnet restore
```

### 4 Configurar banco de dados

No arquivo `appsettings.json`, configure sua conexão. Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=ControleGastosDB;user=root;password=123456;"
  }
}
```

### 5 Executar as migrations

```bash
dotnet ef database update
```

### 6 Executar a API

```bash
dotnet run
```

### 7 Abrir Swagger

```
https://localhost:xxxx/swagger
```

ou

```
http://localhost:xxxx/swagger
```

---

## Frontend

### 8 Entre na pasta

```bash
cd FrontEnd
```

### 9 Instalar dependências

```bash
npm install
```

### 10 Configurar a URL da API

No arquivo `src/services/api.ts`, verifique se a `baseURL` aponta para o endereço correto da API:

```ts
export const api = axios.create({
  baseURL: "http://localhost:5000/api",
});
```

### 11 Executar o frontend

```bash
npm run dev
```

### 12 Acessar a aplicação

```
http://localhost:5173
```

---

# 📌 Endpoints

## Pessoas

### Listar Pessoas

```
GET /api/pessoas
```

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

### Excluir Pessoa

```
DELETE /api/pessoas/{id}
```

Ao excluir uma pessoa, todas as suas transações são removidas automaticamente.

---

## Transações

### Listar Transações

```
GET /api/transacoes
```

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

## Relatório

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

## Transações
- Descrição obrigatória.
- Valor maior que zero.
- Pessoa deve existir.
- Apenas despesas podem ser cadastradas para menores de idade.

---

# 🔒 Tratamento de Exceções

A API utiliza um Middleware global para tratamento de erros. Exemplo:

```json
{
    "sucesso":false,
    "mensagem":"Pessoa não encontrada.",
    "status":404
}
```

---

# ✔ Validações

## Backend

Todas as validações são realizadas utilizando FluentValidation. Exemplo:

```json
{
    "nome":"",
    "idade":-10
}
```

Resposta: `HTTP 400`

## Frontend

As validações de formulário são realizadas no client com **Zod**, exibindo mensagens de erro abaixo de cada campo antes mesmo do envio à API (ex: nome com menos de 3 caracteres, idade fora do intervalo permitido, valor de transação negativo ou zero).

---

# 🛠 Banco de Dados

Relacionamentos:

```
Pessoa 1 ---- N Transações
```

Ao excluir uma pessoa, todas as transações são excluídas automaticamente (Cascade Delete).

---

# 📚 Padrões Utilizados

## Backend
- Arquitetura em Camadas
- Repository Pattern
- Dependency Injection
- DTO Pattern
- Middleware
- FluentValidation
- Entity Framework Core
- REST API

## Frontend
- Component-Based Architecture
- Separação por responsabilidade (pages / components / services / interfaces)
- Camada de serviços dedicada ao consumo da API (Axios)
- Validação de formulários com Schema Validation (Zod)
- Roteamento declarativo com layout compartilhado (React Router)

---

# 📖 Fluxo da Requisição

```
Request (Frontend)
   ↓
Service (Axios)
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
   ↓
Página (Frontend)
```

---

# 👨‍💻 Autor

Desenvolvido por **Geovane Silva**.

GitHub: [https://github.com/GeovaneSilvaP](https://github.com/GeovaneSilvaP)
