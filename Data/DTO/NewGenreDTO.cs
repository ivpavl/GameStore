using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.DTOs;
public class NewGenreDTO
{
    [Required]
    public string Name { get; set; } = default!;
}