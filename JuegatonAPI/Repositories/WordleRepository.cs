using Dapper;
using JuegatonAPI.Models;
using Npgsql;

namespace JuegatonAPI.Repositories
{

    public class WordleRepository
    {
        private PosgreSQLConfig connexionString;
        public WordleRepository(PosgreSQLConfig connexionString)
        {
            this.connexionString = connexionString;
        }
        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }
        public async Task<IEnumerable<Wordle>> GetAllWordles()
        {
            var db = DbConnection();

            var sql = @"SELECT palabra_id, palabra FROM public.""Wordle"";";

            return await db.QueryAsync<Wordle>(sql, new { });

        }
    }
}
