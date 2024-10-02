using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();
  

app.MapGamesEndpoints();

app.Run();