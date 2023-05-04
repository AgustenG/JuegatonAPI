using JuegatonAPI.Models;
using JuegatonAPI.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace JuegatonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordleController : ControllerBase
    {
        private readonly WordleRepository wordleRepository;

        public WordleController(WordleRepository repository)
        {
            wordleRepository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wordle>>> GetAllWordles()
        {
            return Ok(await wordleRepository.GetAllWordles());
        }
    }
}
/*
para elegir elemento de la tabla aleatorio

SELECT *
FROM (table)
WHERE (condition)
ORDER BY random()
LIMIT 1;
*/