
# XPCT - Case Técnico XP [![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

Esta API foi desenvolvida para fornecer funcionalidades de gerenciamento de portfólio de investimentos. Os usuários podem realizar várias operações relacionadas a investimentos, acompanhar os produtos em sua carteira e gerar extratos de investimentos.

## Funcionalidades Principais

- Cadastro, atualização, inativação e ativação de produtos de investimentos.
- Consulta de Produtos no portifólio.
- Consulta de Extrato do portifólio.
- Disparo de E-mails diários para aviso aos clientes dos investimentos que estão prestes a vencer.



## Stack utilizada

**Back-end:** Microsoft .NET Core 7.0


## Instalação e Configuração

1. Clone o repositório:

```bash
git clone https://github.com/Lpasquarelli/XPCT.git
```

2. Navegue até o diretório do projeto:

```bash
cd XPCT
```

3. Execute o seguinte comando para restaurar as dependências:

```bash
dotnet restore
```

4. Após a conclusão das etapas acima, você pode iniciar a API:

```bash
dotnet run

```

5. Caso queira rodar os testes:

- Entre no repositorio de testes
```bash
cd .\XPCT.Test\

```
- Execute o comando de iniciar os testes
```bash
dotnet test

```

A API estará disponível em 'https://localhost:7214'.


# Uso da API

A documentação detalhada da API pode ser encontrada em 'https://localhost:7214/swagger' após iniciar o serviço.


## Esquemas de Autenticação

Existem dois tipos de Role para o usuário "OPERATOR" e "CUSTOMER", onde são definidos na criação do usuário (caso a flag Operator seja marcada como true, ele será um usuário operador) segregando a responsábilidade de apenas usuários Operadores conseguirem Criar, Alterar, Ativar e Invativar Produtos de Investimento e somente clientes poderem consultar extratos, e produtos do seu portfólio, comprar e vender.


![Authorization Schema](https://github.com/Lpasquarelli/XPCT/assets/48439632/958a912e-8154-43bc-afd1-237c36ec8118)


## Parametros

- Para Autenticação, foram deixados 2 Endpoints para autenticação: 1 Endpoint para criação de usuários e 1 Endpoint para Gerar o token JWT de autenticação.
- o JWT deve ser enviado no modelo Authorization Bearer via Header.
- Caso o Usuário não possúa a Role permitida, a API retornará 403 (Forbidden)


## Collection

A Collection do Postman foi disponibilizada juntamente ao código, na raiz do projeto.

## Banco de Dados

Não foi utilizado nenhum banco de dados, apenas Listas simulando a comunicação entre os repositorios.


# Worker

O disparo de emails diários é realizado por um Worker, criado como background service, que ínicia automaticamente junto com a API.







## Licença

[MIT](https://choosealicense.com/licenses/mit/)

