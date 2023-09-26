using GameStore.Data.Entities;
using GameStore.Data.DTOs;

namespace GameStore.Data.Services;
public interface IGameService
{
    IEnumerable<GameModel> GetAllGamesInfo();
    void CreateGame(NewGameDTO newGame);
    string GetGameDescription(string gameAlias);
    void UpdateGame(UpdateGameDTO game);
    void DeleteGame(string gameAlias);
    byte[] GetGameContentForDownload(string gameAlias);
}