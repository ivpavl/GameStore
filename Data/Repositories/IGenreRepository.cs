using GameStore.Data.Entities;

namespace GameStore.Data.Repository;
public interface IGenreRepository
{
    IEnumerable<GenreEntity> GetAll();
    GenreEntity Get(string gameAlias);
    void Create(GenreEntity game);
    void Update(GenreEntity game);
    void Delete(GenreEntity gameAlias);
}
