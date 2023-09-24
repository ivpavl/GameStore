using GameStore.Data.Entities;
using GameStore.Data.Exceptions;

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
        var game = _context.Games.Where(g => g.Alias == gameAlias).FirstOrDefault();
        if (game is null)
        {
            throw new GameNotFoundException($"Game with alias {gameAlias} is not found!");
        }
        return game;
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