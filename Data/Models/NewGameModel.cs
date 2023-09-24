using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models;
public class NewGameModel
{
    public string? Alias { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}