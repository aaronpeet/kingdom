using System;
using System.Collections.Generic;
using kingdom.Models;
using kingdom.Services;
using Microsoft.AspNetCore.Mvc;

namespace kingdom.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly CastlesService _castlesService;

        public CastlesController(CastlesService castlesService)
        {
            _castlesService = castlesService;
        }

    [HttpGet]
    public ActionResult<IEnumerable<Castle>> Get()
    {
        try
        {
            IEnumerable<Castle> castles = _castlesService.Get();
            return Ok(castles) 
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Castle> Get(int id)
    {
        try
        {
            Castle castle = _castlesService.Get(id);
            return Ok(castle); 
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message)
        }
    }

    [HttpPost]
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
        try
        {
           Castle castle = _castlesService.Create(newCastle);
           return Ok(castle);  
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message)
        }
    }

    }
  
}