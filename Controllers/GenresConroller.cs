using GameStore.Data.DTOs;
using GameStore.Data.Entities;
using GameStore.Data.Repository;
using GameStore.Data.Services;
using GameStore.Data.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Orders.WebApi.Controllers;

[Route("/genres")]
[ApiController]
public sealed class GenresConroller : ControllerBase
{
    private readonly IGenreService genreService;
    public GenresConroller(IGenreService genreService)
    {
        this.genreService = genreService;
    }

    [HttpPost("new")]
    public ActionResult NewGenre(NewGenreDTO newGenre)
    {
        genreService.CreateGenre(newGenre);
        return Ok();
    }

}

