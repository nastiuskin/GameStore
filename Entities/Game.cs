﻿namespace GameStore.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; } = String.Empty;
        public int GenreId { get; set; }
        public Genre genre { get; set; }

        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

    }
}