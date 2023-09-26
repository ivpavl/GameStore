using System.Text;
using GameStore.Data.Entities;
using GameStore.Data.DTOs;
using GameStore.Data.UOW;
using GameStore.Data.Utilities;

namespace GameStore.Data.Services;
public class GenreService : IGenreService
{

    private readonly IUnitOfWork unitOfWork;
    public GenreService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void CreateGenre(NewGenreDTO newGenre)
    {
        unitOfWork.Genres.Create(new GenreEntity()
        {
            Name = newGenre.Name
        });
    }
}