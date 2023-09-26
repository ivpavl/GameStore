using GameStore.Data.Entities;
using GameStore.Data.DTOs;

namespace GameStore.Data.Services;
public interface IGenreService
{
    void CreateGenre(NewGenreDTO newGenre);
}