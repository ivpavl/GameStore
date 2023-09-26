using GameStore.Data.Entities;
using GameStore.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data.Repository;

public class GenreRepository : IGenreRepository
{
    private ApplicationDbContext _context;
    public GenreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(GenreEntity genre)
    {
        var existingGenre = _context.Genres.FirstOrDefault(g => g.Name == genre.Name);
        if (existingGenre is not null)
        {
            throw new GenreAliasExistsException($"Genre with name {genre.Name} already exists!");
        }
        _context.Genres.Add(genre);
    }

    public void Delete(GenreEntity gameAlias)
    {
        throw new NotImplementedException();
    }

    public GenreEntity Get(string gameAlias)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GenreEntity> GetAll()
    {
        return _context.Genres.ToArray();
    }

    public void Update(GenreEntity game)
    {
        throw new NotImplementedException();
    }
}