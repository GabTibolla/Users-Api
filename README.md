# API

Este projeto é uma API que utiliza armazenamento em memória cache com Redis e persistência de dados com SQL Server. 

## Dependências

As dependências essenciais para o funcionamento deste projeto incluem:

- **Entity Framework Core**  
  - `C:\Users\pc\.nuget\packages\microsoft.entityframeworkcore` - versão `9.0.0`
  - Descrição: O Entity Framework Core é utilizado para interagir com o banco de dados SQL Server.

- **Entity Framework Core SQL Server**  
  - `microsoft.entityframeworkcore.sqlserver` - versão `9.0.0`
  - Descrição: Este pacote fornece o provedor SQL Server para o Entity Framework Core.

- **Entity Framework Core Tools**  
  - `microsoft.entityframeworkcore.tools` - versão `9.0.0`
  - Descrição: Ferramentas de linha de comando do Entity Framework Core, usadas para migrações e outras operações de manutenção do banco de dados.

- **Microsoft Extensions Caching StackExchangeRedis**  
  - `microsoft.extensions.caching.stackexchangeredis` - versão `9.0.0`
  - Descrição: Integra o StackExchange Redis como um provedor de cache para armazenar dados em memória, ajudando a melhorar o desempenho da API.

- **Swashbuckle.AspNetCore**  
  - `swashbuckle.aspnetcore` - versão `6.6.2`
  - Descrição: Utilizado para gerar a documentação da API com Swagger, facilitando a visualização e testes dos endpoints.

## Armazenamento de Dados

- **Cache em Memória com Redis**:  
  - O armazenamento temporário é feito utilizando Redis, que permite que os dados sejam acessados rapidamente. Redis está configurado para rodar em um contêiner Docker em uma máquina virtual Linux Ubuntu.
  
- **Banco de Dados Persistente com SQL Server**:  
  - O armazenamento persistente é feito com SQL Server, acessado através do Entity Framework Core. Todos os dados críticos são mantidos no banco de dados, enquanto o Redis é usado para cache, acelerando o acesso a informações frequentemente requisitadas.

