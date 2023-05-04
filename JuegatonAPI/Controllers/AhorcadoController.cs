using JuegatonAPI.Models;
using JuegatonAPI.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace JuegatonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AhorcadoController : ControllerBase
    {
        private readonly AhorcadoRepository AhorcadoRepository;

        public AhorcadoController(AhorcadoRepository repository)
        {
            AhorcadoRepository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ahorcado>>> GetAllAhorcados()
        {
            return Ok(await AhorcadoRepository.GetAllAhorcados());
        }
    }
}