using GameStore.Data.Models;
using GameStore.Data.Services;
using GameStore.Data.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Orders.WebApi.Controllers;

[Route("/games")]
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

    [HttpGet("{gameAlias}/download")]
    public ActionResult DownloadGame(string gameAlias)
    {
        string contentType = "text/plain";
        string fileName = GameUtilities.GenerateGameFileName(gameAlias);
        var gameContent = gameService.GetGameContentForDownload(gameAlias);

        return File(gameContent, contentType, fileName);
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

