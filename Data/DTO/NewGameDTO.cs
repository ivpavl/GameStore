using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.DTOs;
public class NewGameDTO
{
    public string? Alias { get; set; } = default!;
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;
}