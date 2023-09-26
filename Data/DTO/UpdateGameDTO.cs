using System.ComponentModel.DataAnnotations;

namespace GameStore.Data.DTOs;
public class UpdateGameDTO
{
    [Required]
    public string OldAlias { get; set; } = default!;
    public string? NewAlias { get; set; } = default!;
    [Required]
    public string OldName { get; set; } = default!;
    public string? NewName { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;

}