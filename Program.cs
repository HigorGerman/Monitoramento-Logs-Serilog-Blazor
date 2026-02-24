using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MySQL;
using SerilogApi.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Serilog com gravação imediata (batchSize: 1)
builder.Host.UseSerilog((context, services, loggerConfig) =>
{
    // String de conexão para o seu Mac via Homebrew (sem senha)
    var connectionString = "Server=localhost;Port=3306;Database=db_logs;Uid=root;Pwd=;";

    loggerConfig
        .ReadFrom.Configuration(context.Configuration) // Lê os filtros do appsettings.json
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.MySQL(
            connectionString: connectionString, 
            tableName: "LogsTrabalho",
            batchSize: 1,  // <--- IMPORTANTE: Garante que o log grave na hora
            storeTimestampInUtc: false 
        );
});

// 2. Adiciona serviços do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// 3. Configuração do Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// 4. Execução com Flush garantido
try
{
    Log.Information("Aplicação Blazor do Higor iniciada com sucesso!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação falhou ao iniciar!");
}
finally
{
    // Garante que nenhum log fique "preso" na memória ao fechar
    Log.CloseAndFlush();
}