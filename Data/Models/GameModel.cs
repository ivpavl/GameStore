namespace GameStore.Data.Entities;
public class GameModel
{
    public GameModel()
    {
    }

    public string Alias { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}


