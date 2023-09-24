using System.ComponentModel.DataAnnotations;
using GameStore.Data.Models;
using GameStore.Data.Utilities;

namespace GameStore.Data.Entities;
public class GameEntity
{
    public GameEntity(NewGameModel newGameModel)
    {
        Name = newGameModel.Name;
        Description = newGameModel.Description;
        Alias = newGameModel.Alias ?? GameUtilities.GenerateUniqueAlias(Name);
    }

    public GameEntity()
    {

    }

    [Key]
    public int Id { get; set; }
    public string Alias { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}


