using System.Collections.Generic;
using System.Data;
using System.Linq;
using kingdom.Models;
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
        
        internal Castle Get(int id)
        {
            string sql = "SELECT * FROM castles WHERE id = @id";
            return _db.QueryFirstOrDefault<Castle>(sql, new { id });
        }

        internal Castle Create(Castle newCastle)
        {
            string sql = @"
            INSERT INTO castles
            (name, population, destroyed)
            VALUES
            (@Name, @Population, @Destroyed);
            SELECT LAST_INSERT_ID();";
            newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
            return newCastle;
        }
    }
}