# Desafio Stefanini


Desenvolver um sistema de gerenciamento de tarefas (To-Do List) que permita ao usuário criar, listar, editar e excluir tarefas.

O desafio pode ser dividido em duas partes principais: desenvolvimento de uma API RESTful utilizando .NET 7 com persistência de dados em MongoDB, um banco de dados NoSQL, e o desenvolvimento de uma aplicação cliente usando Vue.js.


# API RESTful


É possível criar dois objetos, **Itens** e **Categorias**.
Os `itens são as tarefas` em si. As categorias são formas de organizar as tarefas em grupos maiores. As categorias foram criadas para satisfazer a seguinte demanda do desafio:

> Adicionar uma funcionalidade que utilize um serviço de IA para sugerir a categorização das tarefas baseada em sua descrição.


## Endpoint :: Item (tarefas)


| Método | Caminho        | Descrição
|--------|----------------|----------
| GET    | /api/Item      | Obtém uma lista de todas as tarefas
| POST   | /api/Item      | Adiciona uma nova tarefa
| GET    | /api/Item{id}  | Consulta uma tarefa pelo seu ID
| PUT    | /api/Item{id}  | Atualiza as informações de uma tarefa
| DELETE | /api/Item{id}  | Exclui uma tarefa



### Schema


Segue abaixo um exemplo de schema do objeto **Item** utilizado pelos métodos POST e PUT:
```json
{
  "id": "string",
  "title": "string",
  "description": "string",
  "dtCreated": "2024-03-13T02:06:38.441Z",
  "status": "string",
  "categoryId": "string",
  "categoryName": "string"
}
```


## Endpoint :: Category

| Método | Caminho           | Descrição
|--------|-------------------|----------
| GET    | /api/Category     | Obtém uma lista de todas as categorias
| POST   | /api/Category     | Adiciona uma nova categoria
| GET    | /api/Category{id} | Consulta uma categoria pelo seu ID
| PUT    | /api/Category{id} | Atualiza as informações de uma categoria
| DELETE | /api/Category{id} | Exclui uma categoria


### Schema


Segue abaixo um exemplo de schema do objeto **Category** utilizado pelos métodos POST e PUT:
```json
{
  "id": "string",
  "categoryName": "string"
}
```


# Banco de Dados MongoDB

A conexão com o banco de dados, assim como o nome das collections utilizadas, estão configuradas no arquivo `appsettings.json`, localizado na raiz do projeto.

Foi utilizada a connection string padrão do MongoDB: **mongodb://localhost:27017/**


# Aplicação Cliente

