using GameStore.Data.Entities;
using GameStore.Data.Models;

namespace GameStore.Data.Services;
public interface IGameService
{
    void CreateGame(NewGameModel newGame);
    string GetGameDescription(string gameAlias);
    void UpdateGame(UpdateGameModel game);
    void DeleteGame(string gameAlias);
}