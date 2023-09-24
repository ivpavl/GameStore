using GameStore.Data.Entities;
using GameStore.Data.Models;
using GameStore.Data.UOW;
using GameStore.Data.Utilities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Services;
public class GameService : IGameService
{

    private readonly IUnitOfWork unitOfWork;
    public GameService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateGame(NewGameModel newGame)
    {
        unitOfWork.Games.Create(new GameEntity(newGame));
        unitOfWork.Save();
    }


    public string GetGameDescription(string gameAlias)
    {
        var existingGame = unitOfWork.Games.Get(gameAlias);
        return existingGame.Description;
    }

    public void UpdateGame(UpdateGameModel game)
    {
        var existingOldGame = unitOfWork.Games.Get(GameUtilities.GenerateUniqueAlias(game.OldName));

        existingOldGame = new GameEntity
        {
            Id = existingOldGame.Id,
            Name = game.NewName ?? existingOldGame.Name,
            Alias = GameUtilities.GenerateUniqueAlias(game.NewName!) ?? existingOldGame.Alias,
            Description = game.Description
        };

        unitOfWork.Games.Update(existingOldGame);
        unitOfWork.Save();
    }
}