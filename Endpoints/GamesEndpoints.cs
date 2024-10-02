using GameStore.Api.DTOs;
using Microsoft.AspNetCore.Builder;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndpoint = "GetGame";

        private readonly static List<GameDTO> games = new List<GameDTO>
{
    new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)),
    new (
        2,
        "Final Fantasy XIV",
        "Roleplaying",
        59.99M,
        new DateOnly(2010, 9, 30)),
    new (
        3,
        "FIFA 23",
        "Sports",
        69.99M,
        new DateOnly(2010, 9, 29))
};

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games");
            group.MapGet("/", () => games);

            group.MapGet("/{id}", (int id) =>
            {
                GameDTO? game = games.Find((game) => game.Id == id);
                return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetGameEndpoint);


            group.MapPost("/", (CreateGameDTO createdGame) =>
            {
                GameDTO game = new GameDTO(
                    games.Count + 1,
                    createdGame.Name,
                    createdGame.Genre,
                    createdGame.Price,
                    createdGame.ReleaseDate);

                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndpoint, new { id = game.Id }, game);
            });
            

            group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);

                if (index == -1) Results.NotFound();

                games[index] = new GameDTO(
                    id,
                    updatedGame.Name,
                    updatedGame.Genre,
                    updatedGame.Price,
                    updatedGame.ReleaseDate
                    );

                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id) =>
            {
                var game = games.Find((game) => game.Id == id);
                games.Remove(game);
            });

            return group;
        }
    }
}
