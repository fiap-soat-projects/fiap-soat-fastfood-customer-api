# 🍔 FastFood Customer API

Este projeto foi desenvolvido para o curso de [pós-graduação em Arquitetura de Software (Soat Póstech) da FIAP](https://postech.fiap.com.br/curso/software-architecture/).

A API presente neste repositório disponibiliza rotas para gerenciamento de clientes da operação de FastFood.

## 🏃 Integrantes do grupo

- Jeferson dos Santos Gomes - **RM 362669**
- Jamison dos Santos Gomes - **RM 362671**
- Alison da Silva Cruz - **RM 362628**

## 👨‍💻 Tecnologias Utilizadas

- **.NET 10** (C# 14)
- **ASP.NET Core Web API**
- **Postgres** (banco de dados)
- **Entity Framework Core** (ORM)
- **Docker** e **Docker Compose**
- **Kubernetes** (gerenciamento de containers)
- **Scalar** (documentação automática)

## Endpoints Disponíveis

### 🤝 Customer (Cliente)

- `GET /v1/customer/{id}` - Informações do cliente.
- `GET /v1/customer?cpf={cpf}` - Informações do cliente.
- `POST /v1/customer` - Cria o registro do cliente.
- `PATCH /v1/customer/{id}` - Atualiza o registro do cliente.
- `DELETE /v1/customer/{id}` - Remove o registro do cliente.

## 👤 Convenções

- Todos os endpoints aceitam e retornam JSON.
- Utilize o Scalar para explorar e testar os endpoints.

## 🏦 Banco de Dados

Neste projeto utilizamos o [`Postgres`](https://www.postgresql.org/) e o modelo de cliente (customer) segue a estrutura abaixo:

| Campo     | Tipo          |
|-----------|---------------|
| Id        | int           |
| Name      | string        |
| Cpf       | string        |
| Email     | string/null   |
| CreatedAt | datetime      |
| UpdatedAt | datetime/null |

---