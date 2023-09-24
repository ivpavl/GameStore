using GameStore.Data.Entities;
using GameStore.Data.Exceptions;
using GameStore.Data.Models;
using GameStore.Data.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Orders.WebApi.Controllers;

[Route("/game")]
[ApiController]
public sealed class GameController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public GameController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("/test")]
    public ActionResult<string> TestAPI()
    {
        var a = unitOfWork.Games.GetAll();
        return Ok(a);
    }

    [HttpPost]
    [Route("/new")]
    public ActionResult<string> NewGame([FromBody]NewGameModel newGame)
    {
        try
        {
            unitOfWork.Games.Create(new GameEntity(newGame));
            unitOfWork.Save();
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [Route("/games/{gamealias}")]
    public ActionResult<string> GetGameDescription(string gamealias)
    {
        try
        {
            var game = unitOfWork.Games.Get(gamealias);
            return Ok(game.Description);
        }
        catch (GameNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}

