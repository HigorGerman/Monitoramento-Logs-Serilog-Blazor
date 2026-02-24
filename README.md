# 🚀 Monitoramento de Gastos com Serilog & Blazor

Este projeto foi desenvolvido como parte do estágio supervisionado e das atividades acadêmicas do 7º termo de Sistemas de Informação na **Unoeste**. O objetivo é demonstrar a implementação prática de **Observabilidade** e **Logging Estruturado** em aplicações .NET modernas.

## 🛠️ Tecnologias Utilizadas
* **C# .NET 10**: Framework principal da aplicação.
* **Blazor Web App**: Utilizado com o modo de renderização `Interactive Server` para garantir interatividade em tempo real.
* **Serilog**: Biblioteca de logging configurada com múltiplos *sinks* (Console e MySQL).
* **MySQL**: Banco de dados relacional utilizado para a persistência dos logs.

## 🌟 Diferenciais do Projeto
* **Logs de Nível Diferenciado**: Separação clara entre logs de fluxo (`Information`) e registros de falhas (`Error`).
* **Captura de Stack Trace**: Implementação de blocos `try-catch` que enviam o rastro completo da exceção para a coluna `Exception` do banco de dados.
* **Otimização de Performance**: Configuração de `batchSize: 1` para gravação imediata no banco de dados, ideal para auditoria em tempo real.
* **Filtros de Ruído**: Configuração de `Overrides` no `appsettings.json` para filtrar logs redundantes do framework Microsoft e focar nos eventos de negócio.

## ⚙️ Como Executar o Projeto

1. **Configuração do Banco de Dados**:
   - Certifique-se de ter o MySQL instalado e rodando.
   - Crie um banco de dados chamado `db_logs`.
   
2. **Configuração do Projeto**:
   - Clone o repositório.
   - Verifique a *connection string* no arquivo `Program.cs`.

3. **Rodar a Aplicação**:
   ```bash
   dotnet run
