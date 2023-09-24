using System.Net;
using GameStore.Data.Entities;
using GameStore.Data.Exceptions;
using GameStore.Data.Models;
using GameStore.Data.Services;
using GameStore.Data.UOW;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpPost]
    [Route("/new")]
    public ActionResult NewGame([FromBody]NewGameModel newGame)
    {
        try
        {
            gameService.CreateGame(newGame);
            return Ok();
        }
        catch (GameAliasExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [Route("/games/{gameAlias}")]
    public ActionResult<string> GetGameDescription(string gameAlias)
    {
        try
        {
            return Ok(gameService.GetGameDescription(gameAlias));
        }
        catch (GameNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Route("/games/update")]
    public ActionResult<string> UpdateGame([FromBody]UpdateGameModel game)
    {
        try
        {
            gameService.UpdateGame(game);            
            return Ok();
        }
        catch (GameNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

}

