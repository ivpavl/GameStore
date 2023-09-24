using GameStore.Data.Entities;
using GameStore.Data.Models;
using GameStore.Data.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Orders.WebApi.Controllers;

[Route("/game")]
[ApiController]
public sealed class GameController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public GameController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("/test")]
    public ActionResult<string> TestAPI()
    {
        var a = _unitOfWork.Games.GetAll();
        return Ok(a);
    }


}

