# Sprint4-.NET

# Odontoprev API

## Introdução
A **Odontoprev API** é uma aplicação desenvolvida em **.NET Core** utilizando **Entity Framework** e **Oracle SQL**. Além disso, conta com integração de **Machine Learning** via **ML.NET** para análise de sentimentos, autenticação via serviços externos RESTful, e testes automatizados com **xUnit**.

## Arquitetura do Projeto
O projeto foi desenvolvido seguindo uma **arquitetura monolítica**, que foi escolhida em detrimento de uma abordagem baseada em **microservices**.

### Justificativa da Arquitetura
A escolha por uma **arquitetura monolítica** se deve aos seguintes fatores:

- **Facilidade de Desenvolvimento**: Como o sistema ainda está em fase inicial, manter um monólito reduz a complexidade do desenvolvimento e facilita a manutenção.
- **Menor Sobrecarga Operacional**: Implementar uma arquitetura de **microservices** exigiria a gestão de múltiplas instâncias, comunicação via APIs, e orquestração de serviços, o que poderia ser um overhead desnecessário nesta fase do projeto.
- **Escalabilidade Vertical**: O sistema pode ser otimizado dentro de uma estrutura monolítica antes de ser modularizado em microservices conforme a necessidade de escalabilidade futura.

### Diferenças entre Monolito e Microservices
| Característica              | Monolito                                      | Microservices                                |
|----------------------------|-----------------------------------------------|----------------------------------------------|
| **Complexidade**            | Baixa                                         | Alta                                         |
| **Facilidade de Manutenção**| Simples no início, mas pode ficar difícil com o tempo | Mais difícil de gerenciar, mas escalável    |
| **Desempenho**              | Melhor para cargas menores                     | Melhor para distribuição de carga            |
| **Escalabilidade**          | Vertical                                      | Horizontal                                   |
| **Tempo de Desenvolvimento**| Rápido                                        | Mais demorado                                |

## Endpoints da API

### Usuário

- **Criar Usuário**  
  - **Endpoint:** `POST /api/usuario/cadastrar`  
  - **Descrição:** Cadastra um novo usuário na base de dados.  
  - **Exemplo de Requisição:**
    ```json
    {
        "Id": "1",
        "Nome": "joao",
        "CPF": "12345678900"
    }
    ```

- **Buscar Usuário por ID**  
  - **Endpoint:** `GET /api/usuario/{id}`  
  - **Descrição:** Retorna os dados do usuário correspondente ao ID informado.

- **Atualizar Usuário**  
  - **Endpoint:** `PUT /api/usuario/atualizar/{id}`  
  - **Descrição:** Atualiza os dados do usuário com o ID especificado.

- **Remover Usuário**  
  - **Endpoint:** `DELETE /api/usuario/apagar/{id}`  
  - **Descrição:** Remove o usuário da base de dados.

### Análise de Sentimento

- **Endpoint:** `POST /api/sentiment`  
- **Descrição:** Recebe um texto e retorna análise de sentimento (positivo ou negativo).  
- **Exemplo de Requisição:**
  ```json
  {
      "text": "ruim!"
  }

![image](https://github.com/user-attachments/assets/9936dda5-a858-443f-a605-e457e9d68796)

### Membros do Grupo
- **Enzo Franco Rocha** - RM: 553643
- **João Pedro Pereira** - RM: 553698
- **Herbert Santos de Sousa** - RM: 553227



