using System.Collections.Generic;
using System.Data;
using System.Linq;
using artistapi.Models;
using Dapper;

namespace kingdom.Repositories
{
    public class CastlesRepository
    {
        private readonly IDbConnection _db;

        public CastlesRepository(IDbConnection db)
        {
            _db =db;
        }

        internal List<Castle> Get()
        {
            string sql = "SELECT * FROM castles";
            return _db.Query<Castle>(sql).ToList();
        }

        
    }
}