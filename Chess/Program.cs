using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Chess;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<Engine>()
    .AddSingleton<ConsoleDisplay>()
    .AddScoped<ChessGame>()
    .AddScoped<Board>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var chessGame = scope.ServiceProvider.GetRequiredService<ChessGame>();
    chessGame.Start();
}