using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using BetHouse.Odds.Repository;

namespace BetHouse.Odds.Controllers;

[Route("[controller]")]
public class OddController : Controller
{
    private readonly IOddRepository _repository;
    public OddController(IOddRepository repository)
    {
        _repository = repository;
    }

    [HttpPatch("{MatchId:int}/{TeamId:int}/{BetValue}")]

    public IActionResult Patch(int MatchId, int TeamId, string BetValue)
    {
        try
        {
            var match = _repository.Patch(MatchId, TeamId, BetValue);

            if (match is null) return BadRequest();

            return Ok(match);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
