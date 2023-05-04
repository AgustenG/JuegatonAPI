using Microsoft.EntityFrameworkCore;

namespace JuegatonAPI.Models
{
    public class PosgreSQLConfig : DbContext
    {
        protected readonly IConfiguration Configuration;
        public string ConnectionString;

        /// <summary>
        /// Método que lee la configuración de conexión a nuestra base de datos del fichero 
        /// appsetting.json
        /// </summary>
        /// <param name="configuration"></param>
        public PosgreSQLConfig(IConfiguration configuration)
        {
            Configuration= configuration;
            ConnectionString = configuration.GetConnectionString("JuegatonDB");
        }
        public DbSet<Jugador> jugador { get; set; }

    }
}
