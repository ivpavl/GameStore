using System.Text;
using GameStore.Data.Entities;
using GameStore.Data.DTOs;
using GameStore.Data.UOW;
using GameStore.Data.Utilities;

namespace GameStore.Data.Services;
public class GameService : IGameService
{

    private readonly IUnitOfWork unitOfWork;
    public GameService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateGame(NewGameDTO newGame)
    {
        unitOfWork.Games.Create(new GameEntity()
        {
            Name = newGame.Name,
            Description = newGame.Description,
            Alias = newGame.Alias ?? GameUtilities.GenerateUniqueAlias(newGame.Name)
        });
        unitOfWork.Save();
    }

    public void DeleteGame(string gameAlias)
    {
        GameEntity game = unitOfWork.Games.Get(gameAlias);
        unitOfWork.Games.Delete(game);
    }

    public IEnumerable<GameModel> GetAllGamesInfo()
    {
        IEnumerable<GameEntity> allGamesEntities = unitOfWork.Games.GetAll();
        
        IEnumerable<GameModel> gameModels = allGamesEntities.Select(gameEntity => new GameModel
        {
            Alias = gameEntity.Alias,
            Name = gameEntity.Name,
            Description = gameEntity.Description
        });

        return gameModels;
    }

    public byte[] GetGameContentForDownload(string gameAlias)
    {
        string textContent = $"Some text content for {gameAlias}.";
        byte[] bytes = Encoding.UTF8.GetBytes(textContent);
        return bytes;
    }

    public string GetGameDescription(string gameAlias)
    {
        GameEntity existingGame = unitOfWork.Games.Get(gameAlias);
        return existingGame.Description;
    }

    public void UpdateGame(UpdateGameDTO game)
    {
        var existingOldGame = unitOfWork.Games.Get(GameUtilities.GenerateUniqueAlias(game.OldName));

        existingOldGame = new GameEntity
        {
            Id = existingOldGame.Id,
            Name = game.NewName ?? existingOldGame.Name,
            Alias = game.NewAlias ?? existingOldGame.Alias,
            Description = game.Description
        };

        unitOfWork.Games.Update(existingOldGame);
        unitOfWork.Save();
    }
}