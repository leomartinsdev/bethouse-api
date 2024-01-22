# Bet House API 💰
Software de um site de apostas no formato de uma RESTful API com operações de CRUD.
O objetivo principal do projeto foi reorganizar um projeto já implementado em arquitetura monolítica para uma arquitetura de microsserviços.
Além disso, foram adicionadas novas features no software (Odds).
<br><br>
O projeto foi feito utilizando C#, ASP.NET Core, .NET 6.0, Microsoft SQL Server, Entity Framework Core (ORM) para gerenciamento do banco de dados e dockerizado para fácil execução em qualquer máquina.<br><br>
A autenticação e autorização foi feita com JWT.<br><br>

## Feito com 👨‍💻:
- C#
- .NET 6.0
- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server
- Microsserviços
- Docker
- JWT

## Diagrama ER
![Model databases](https://github.com/leomartinsdev/bethouse-api/assets/117598788/b1a6678f-451d-4850-b832-9c8c222c4118)


## Organização dos Microsserviços:
![Model databases - Page 1](https://github.com/leomartinsdev/bethouse-api/assets/117598788/9338d15a-2fc0-4297-a122-1e017e3c35b1)

### BetHouse.Users:
- Funcionalidades: responsável pelo cadastro e login de usuários.
- Fonte: /src/BetHouse.Users
- Porta: 5501
- Rotas: POST /user/signup e POST user/login

### BetHouse.Matches
- Funcionalidades: responsável pela visualização de times e partidas.
- Fonte: /src/BetHouse.Matches
- Porta: 5502
- Rotas: GET /team e GET /match/{finished}

### BetHouse.Bets
- Funcionalidades: responsável pelo cadastro e visualização de apostas.
- Fonte: /src/BetHouse.Bets
- Porta: 5503
- Rotas: POST /bet e GET /bet/{BetId}

### BetHouse.Odds
- Funcionalidades: responsável pela atualização das odds de cada partida. Ele é utilizado pelo microsserviço BetHouse.Bets e será chamado por este toda vez que uma nova aposta for cadastrada.
- Fonte: /src/BetHouse.Odds
- Porta: 5504
- Rotas: PATCH /odd/{matchId}/{TeamId}/{BetValue}
