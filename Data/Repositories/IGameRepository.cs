using GameStore.Data.Entities;

namespace GameStore.Data.Repository;
public interface IGameRepository
{
    IEnumerable<GameEntity> GetAll();
    GameEntity Get(string gameAlias);
    void Create(GameEntity game);
    void Update(GameEntity game);
    void Delete(GameEntity gameAlias);
}
