using System.ComponentModel.DataAnnotations;
using GameStore.Data.Models;
using GameStore.Data.Utilities;

namespace GameStore.Data.Entities;
public class GenreEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public virtual ICollection<GenreEntity> Children { get; set; } = default!;
}


