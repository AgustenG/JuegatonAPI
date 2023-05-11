using Dapper;
using JuegatonAPI.Models;
using Npgsql;

namespace JuegatonAPI.Repositories
{
  
    public class JugadorRepository
    {
        private PosgreSQLConfig connexionString;
        public JugadorRepository(PosgreSQLConfig connexionString)
        {
            this.connexionString = connexionString;
        }
        /// <summary>
        /// Método que devuelve una conexión a la base de datos
        /// </summary>
        /// <returns></returns>
        protected NpgsqlConnection DbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }
        /// <summary>
        /// Método que devuelve un select de todos los campos de la tabla Jugador
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Jugador>> GetAllJugadores()
        {
            var db = DbConnection();

            var sql = @"SELECT nombre, apellidos, nickname, password, pais, color, posicion, puntuacion FROM public.""Jugador"";";

            return await db.QueryAsync<Jugador>(sql,new { } );

        }
        /// <summary>
        /// Método que recibe un nickname y devuelve el jugador con dicho nickname
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public async Task<Jugador> GetJugador(string nickname)
        {
            var db = DbConnection();

            var sql = @"SELECT nombre, apellidos, nickname, password, pais, color, posicion, puntuacion FROM public.""Jugador"" WHERE nickname = @Nickname;";

            return await db.QueryFirstOrDefaultAsync<Jugador>(sql, new { Nickname = nickname });

        }
        /// <summary>
        /// Método que recibe un objeto Jugador y lo inserta en la base de datos, en caso de no poder insertarlo devuelve false 
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public async Task<bool> InsertJugador (Jugador jugador)
        {
            var db = DbConnection();
            var sql = @"
                        INSERT INTO public.""Jugador""(nombre, apellidos, nickname, password, pais, color)
                        VALUES (@nombre, @apellidos, @nickname, @password, @pais, @color)";
            var result = await db.ExecuteAsync(sql, new {jugador.Nombre, jugador.Apellidos, jugador.Nickname, jugador.Password, jugador.Pais, jugador.Color });
            return result > 0;
        }

        /// <summary>
        /// Método que recibe un Jugador y hace un update al jugador con el mismo nickname en caso de no encontrarlo, devuelve 0
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public async Task<bool> UpdateJugador(Jugador jugador)
        {
            var db = DbConnection();

            var sql = @"
                        UPDATE  public.""Jugador""
                        SET nombre = @nombre,
                            apellidos  =  @apellidos,
                            nickname = @nickname,
                            password = @password,
                            pais = @pais,
                            color = @color
                        WHERE nickname = @Nickname;
                        ";

            var result = await db.ExecuteAsync(sql, new { jugador.Nombre, jugador.Apellidos, jugador.Nickname, jugador.Password, jugador.Pais, jugador.Color});
            return result > 0;
        }

        public async Task<bool> DeletePlayer(string nickname)
        {
            var db = DbConnection();

            var sql = @"
                        DELETE FROM  public.""Jugador""
                        WHERE nickname = @Nickname;
                        ";

            var result = await db.ExecuteAsync(sql, new { nickname });


            return result > 0;
        }
        public async Task<bool> UpdateScore(int Puntuacion, string Nickname)
        {
            
            var db = DbConnection();

            var sql = @"
                        UPDATE public.""Jugador""
                        SET puntuacion = @puntuacion
                        WHERE nickname = @nickname;
                        ";

            
            var result = await db.ExecuteAsync(sql, new { Puntuacion , Nickname});
            return result > 0;
        }
    }
}
