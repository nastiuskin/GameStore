using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs
{
    public record CreateGameDTO
    (
    [Required]
    [StringLength(50)]
     string Name,

    [Required]
    [StringLength(30)]
     string Genre,

    [Required]
     decimal Price,

    [Required]
     DateOnly ReleaseDate);
}
