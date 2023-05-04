using JuegatonAPI.Models;
using JuegatonAPI.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace JuegatonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardRepository leaderboardRepository;

        public LeaderboardController(LeaderboardRepository repository)
        {
            leaderboardRepository = repository;
        }
        // GET: api/Leaderboard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leaderboard>>> GetAllLeaderboards()
        {
            return Ok(await leaderboardRepository.GetAllLeaderboardes());
        }

        // GET: api/Leaderboard/Nickname
        [HttpGet("{nickname}")]
        public async Task<ActionResult<IEnumerable<Leaderboard>>> GetLeaderboard(string nickname)
        {
            return Ok(await leaderboardRepository.GetLeaderboard(nickname));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeaderboard([FromBody] Leaderboard leaderboard)
        {
            if (leaderboard == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await leaderboardRepository.InsertLeaderboard(leaderboard);
            return Created("creado!", created);
        }
    }
}
