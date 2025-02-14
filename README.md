# Banco Krt

Este projeto é uma aplicação CRUD para gerenciar entidades de clientes e realizar transferências de dinheiro entre eles. Segue os princípios de Domain-Driven Design (DDD), Clean Architecture e SOLID, utilizando o DynamoDB como banco de dados. Os testes unitários foram implementados com FluentAssertions.

## Tecnologias Utilizadas
- .NET 8.0
- DynamoDB

## Visão Geral da Arquitetura
- **DDD**: Foco na lógica de negócios principal.
- **Clean Architecture**: Separação clara entre as camadas da aplicação.
- **SOLID**: Código com alta manutenibilidade e extensibilidade.

## Funcionalidades
- Criar, ler, atualizar e excluir registros de clientes.
- Realizar transferências de dinheiro entre clientes com segurança.
- Validação de entradas com FluentValidation.

## Configuração de Ambiente
- Configure a conexão com o DynamoDB através de variáveis de ambiente.

