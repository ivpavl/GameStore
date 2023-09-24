using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models;
public class NewGameModel
{
    public string? Alias { get; set; } = default!;
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;
}