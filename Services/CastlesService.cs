using System;
using System.Collections.Generic;
using artistapi.Models;
using artistapi.Repositories;

namespace kingdom.Services
{
    public readonly CastlesRepository _repo;

    public CastlesService(CastlesRepository repo)
    {
        _repo = repo;
    }

    internal IEnumerable<Castle> Get()
    {
        return _repo.Get();
    }

    internal Castle Get(int id)
    {
        Castle castle = _repo.Get(id);
        if(castle == null)
        {
            throw new Exception("Invalid ID")
        }
        return castle;
    }

    internal Castle Create(Castle newCastle)
    {
        Castle castle = _repo.Create(newCastle);
        if(castle == null)
        {
            throw new Exception("Invalid ID");
        }
        return castle;
    }
}