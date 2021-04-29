# Avaliação técnica
### Guilherme Ferreira da Silva Dorazzi

Aplicação basicamente que permite realizar as operações CRUD nas tabelas de categorias e produtos.

# Tutorial

### Banco de dados

Banco: MySQL
Dentro da pasta [/Banco](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/tree/main/Banco) você vai encontrar os scripts de banco que devem ser executados na seguinte ordem:
 - 01_CREATE_TABLES_CATEGORAIAS_PRODUTOS_20210422
 - 02_INSERT_TB_CATEGORIAS_20210422.sql
 - 03_ALTER_TB_PRODUTOS_20210422.sql
 - 04_INSERT_TB_PRODUTOS_20210422.sql

###### OBS: Nos scripts não é realizada a criação do schema, para dar maior flexibilidade para quem for realizar os testes e quiser configurar seu próprio schema.

### API

Api: .NET Core 3.1
Dentro da pasta [/Api/Citel.Api/](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/tree/main/Api) existe o projeto da API com .NET Core 3.1 que contempla as apis de Categorias e Produtos. Existe também um compilado que está na pasta [/Compilados/Api[1.0.1].rar](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/blob/main/Compilados/Api%5B1.0.1%5D.rar)

###### OBS: Precisa configurar a string de conexão no "appsettings.json" para você conseguir se concetar no seu banco de dados, lembre de inserir o usuario, senha, host e o nome da base. 

### Swagger

Foi realizado a criação do swagger para mapear as APIs existentes, você pode importar o arquivo no seu Postman, o arquivo está na pasta [/Swagger](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/blob/main/Swagger/swagger.yaml).

### Web App

Web App: Angular 11

Foi realizado a criação de um projeto angular para contemplar o consumo das APIs que foram criadas para realização do CRUD de categorias e produtos, o memso se encontra na pasta [AppWeb/avaliacao-citel/](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/tree/main/AppWeb/avaliacao-citel) e também existe um compilado na pasta [Compilados/WebApp[0.0.1].rar](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/blob/main/Compilados/WebApp%5B0.0.1%5D.rar).

Para configurar o diretorio base da API navegue até o arquivo [AppWeb/avaliacao-citel/src/app/services/base.service.ts](https://github.com/GuilhermeDorazzi/avaliacao-tecnica/blob/main/AppWeb/avaliacao-citel/src/app/services/base.service.ts) e altere a url conforme desejada, e com isso as chamadas serão direcionadas para a url selecionada.

```sh
export class BaseService {
  url = 'custom url';
```

Para você executar o projeto angular execute o comando abaixo:
```sh
//Talvez você precise executar o comando "ng install" antes para ele baixar as dependencias do projeto
ng serve
```

###### OBS: O projeto compilado está apontado para a url base "http://localhost:9032", caso queira rodar o compilado garanta que a API esteja rodando localhost na mesma porta configurada. 

### Considerações

> Espero que esse tutorial esteja facil de ser aplicado
> e muito obrigado pela oportunidade. 