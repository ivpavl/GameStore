using GameStore.Data.Entities;

namespace GameStore.Data.Repository;

public class GameRepository : IGameRepository
{
    private ApplicationDbContext _context;
    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(GameEntity game)
    {
        _context.Games.Add(game);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public GameEntity Get(string gameAlias)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GameEntity> GetAll()
    {
        return _context.Games;
    }

    public void Update(GameEntity game)
    {
        throw new NotImplementedException();
    }
}