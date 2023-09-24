using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.Models;
public class UpdateGameModel
{
    public string? OldAlias { get; set; } = default!;
    public string? NewAlias { get; set; } = default!;
    public string OldName { get; set; } = default!;
    public string? NewName { get; set; } = default!;
    public string Description { get; set; } = default!;

}