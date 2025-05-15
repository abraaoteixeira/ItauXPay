# ItauXPay

<p align="center">
  <img src="https://github.com/abraaoteixeira/ItauXPay/blob/main/logo-ItauXPay.png?raw=true" alt="Logo do ItauXPay" width="300" style="border-radius: 50px;" />
</p>

**ItauXPay** é uma API de pagamentos desenvolvida em C#/.NET, projetada para integrar sistemas de pagamento utilizando a API do Itaú e um banco de dados PostgreSQL. Este projeto tem como objetivo oferecer uma solução simples, eficiente e escalável para o gerenciamento de transações financeiras, fornecendo endpoints para processar, consultar e gerenciar pagamentos.

## Principais Funcionalidades

- **Integração com a API do Itaú**:
  - Processamento de pagamentos em tempo real.
  - Comunicação segura com a API de pagamentos do Itaú.
- **Banco de Dados PostgreSQL**:
  - Armazenamento seguro e estruturado de informações de pagamentos.
  - Suporte a operações de consulta, criação e atualização de registros.
- **Documentação com Swagger**:
  - Endpoints documentados e testáveis diretamente via interface Swagger.
- **Desenvolvimento em .NET**:
  - Utiliza as melhores práticas de desenvolvimento em C# e .NET.
  - Arquitetura modular e extensível.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C# (.NET 6 ou superior)
- **Banco de Dados**: PostgreSQL
- **Integração de API**: API de pagamentos do Itaú
- **Documentação e Teste**: Swagger (Swashbuckle)
- **Gerenciamento de Dependências**: NuGet
- **Hospedagem e Deploy**: Compatível com Azure, AWS, Docker, etc.

## Pré-requisitos

Antes de começar, certifique-se de que você tenha os seguintes requisitos instalados e configurados:

1. **.NET SDK** (versão 6 ou superior):
   - [Download .NET SDK](https://dotnet.microsoft.com/download)
2. **PostgreSQL** (versão 13 ou superior):
   - [Download PostgreSQL](https://www.postgresql.org/download/)
3. **Credenciais da API do Itaú**:
   - É necessário configurar credenciais de acesso para consumir a API de pagamentos do Itaú.
4. **Git**:
   - Para clonar e versionar o repositório.
   - [Download Git](https://git-scm.com/)
5. **Docker** (opcional):
   - Para rodar o ambiente localmente com containers, incluindo o banco de dados PostgreSQL.

## Instalação e Configuração

1. Clone este repositório:
   ```bash
   git clone https://github.com/abraaoteixeira/ItauXPay.git
   cd ItauXPay
   ```

2. Configure o banco de dados PostgreSQL:
   - Crie um banco de dados chamado `ItauXPayDB`.
   - Atualize a string de conexão no arquivo `appsettings.json` com as credenciais do banco.

3. Instale as dependências do projeto:
   ```bash
   dotnet restore
   ```

4. Execute as migrações para configurar o banco de dados:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Configure as credenciais da API do Itaú:
   - Adicione suas credenciais no arquivo de configuração.

6. Inicie o servidor:
   ```bash
   dotnet run
   ```

7. Acesse a interface do Swagger para testar os endpoints:
   - URL padrão: `http://localhost:5000/swagger`

## Estrutura de Endpoints

- **/api/payments** (POST):
  - Processa um novo pagamento.
- **/api/payments** (GET):
  - Lista todos os pagamentos registrados.
- **/api/payments/{id}** (GET):
  - Retorna os detalhes de um pagamento específico.
- **/api/payments/{id}** (PUT):
  - Atualiza o status de um pagamento.
- **/api/payments/{id}** (DELETE):
  - Remove um pagamento do banco de dados.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests para melhorias no projeto.

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).

## Contato

Criado por **Abraão Teixeira**  
[![GitHub](https://img.shields.io/badge/GitHub-abraaoteixeira-informational)](https://github.com/abraaoteixeira)