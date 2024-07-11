using API_ProjectHammeau.Moddels;
using API_ProjectHammeau.Tools;
using Labo_BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ProjectHammeau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpPost]
        public IActionResult Create(GamesCreateForm form)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _gameService.Create(form.ToDOMAIN());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
