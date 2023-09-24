using GameStore.Data.Entities;
using GameStore.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

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
        var existingGame = _context.Games.FirstOrDefault(g => g.Alias == game.Alias);
        if (existingGame is not null)
        {
            throw new GameAliasExistsException($"Game with alias {game.Alias} already exists!");
        }
        _context.Games.Add(game);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public GameEntity Get(string gameAlias)
    {
        return _context.Games
            .AsNoTracking()
            .FirstOrDefault(g => g.Alias == gameAlias)
            ?? throw new GameNotFoundException($"Game with alias {gameAlias} is not found!");
    }

    public IEnumerable<GameEntity> GetAll()
    {
        return _context.Games;
    }

    public void Update(GameEntity game)
    {
        _context.Games.Update(game);
    }
}