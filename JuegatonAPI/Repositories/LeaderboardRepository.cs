using Dapper;
using JuegatonAPI.Models;
using Npgsql;

namespace JuegatonAPI.Repositories
{

    public class LeaderboardRepository
    {
        private PosgreSQLConfig connexionString;
        public LeaderboardRepository(PosgreSQLConfig connexionString)
        {
            this.connexionString = connexionString;
        }
        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }
        public async Task<IEnumerable<Leaderboard>> GetAllLeaderboardes()
        {
            var db = DbConnection();

            var sql = @"SELECT posicion, nickname, puntuacion, pais FROM public.""Leaderboard"";";

            return await db.QueryAsync<Leaderboard>(sql, new { });

        }
        public async Task<Leaderboard> GetLeaderboard(string nickname)
        {
            var db = DbConnection();

            var sql = @"SELECT posicion, nickname, puntuacion, pais FROM public.""Leaderboard"" WHERE nickname = @Nickname;";

            return await db.QueryFirstOrDefaultAsync<Leaderboard>(sql, new { Nickname = nickname });

        }

        public async Task<bool> InsertLeaderboard(Leaderboard Leaderboard)
        {
            var db = DbConnection();
            var sql = @"
                        INSERT INTO public.""Leaderboard""(nickname, puntuacion, pais)
                        VALUES ( @nickname, @puntuacion, @pais)";
            var result = await db.ExecuteAsync(sql, new {Leaderboard.Nickname, Leaderboard.Puntuacion, Leaderboard.Pais});
            return result > 0;
        }

        public async Task<bool> UpdateLeaderboard(Leaderboard Leaderboard)
        {
            var db = DbConnection();

            var sql = @"
                        UPDATE  public.""Leaderboard""
                        SET posicion = @posicion,
                            nickname = @nickname,
                            puntuacion = @puntuacion,
                            pais = @pais,
                        WHERE nickname = @Nickname;
                        ";

            var result = await db.ExecuteAsync(sql, new { Leaderboard.Posicion, Leaderboard.Nickname, Leaderboard.Puntuacion, Leaderboard.Pais });
            return result > 0;
        }

    }
}
