using Dapper;
using JuegatonAPI.Models;
using Npgsql;

namespace JuegatonAPI.Repositories
{
    public class AhorcadoRepository
    {
        private PosgreSQLConfig connexionString;
        public AhorcadoRepository(PosgreSQLConfig connexionString)
        {
            this.connexionString = connexionString;
        }
        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }
        public async Task<IEnumerable<Wordle>> GetAllAhorcados()
        {
            var db = DbConnection();

            var sql = @"SELECT palabra_id, palabra FROM public.""Ahorcado"";";

            return await db.QueryAsync<Wordle>(sql, new { });

        }
    }
}
