using GameStore.Data.Exceptions;
using GameStore.Data.Models;
using GameStore.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Orders.WebApi.Controllers;

[Route("/game")]
[ApiController]
public sealed class GameController : ControllerBase
{
    private readonly IGameService gameService;
    public GameController(IGameService gameService)
    {
        this.gameService = gameService;
    }

    [HttpPost("new")]
    public ActionResult NewGame([FromBody]NewGameModel newGame)
    {
        gameService.CreateGame(newGame);
        return Ok();
    }

    [HttpGet("{gameAlias}")]
    public ActionResult<string> GetGameDescription(string gameAlias)
    {
        return Ok(gameService.GetGameDescription(gameAlias));
    }

    [HttpPost("update")]
    public ActionResult UpdateGame([FromBody]UpdateGameModel game)
    {
        gameService.UpdateGame(game);            
        return Ok();
    }

    [HttpDelete("remove")]
    public ActionResult RemoveGame(string gameAlias)
    {
        gameService.DeleteGame(gameAlias);            
        return NoContent();
    }

}

