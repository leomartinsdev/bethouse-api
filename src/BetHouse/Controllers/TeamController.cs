using System;
using Microsoft.AspNetCore.Mvc;
using BetHouse.Repository;



namespace BetHouse.Controllers;

[Route("[controller]")]
public class TeamController : Controller
{
    private readonly ITeamRepository _repository;
    public TeamController(ITeamRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.Get());
    }
}