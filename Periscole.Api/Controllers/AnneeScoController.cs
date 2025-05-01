using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periscole.Api.Interfaces;
using Periscole.Api.Services;

namespace Periscole.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnneeScoController : ControllerBase
    {
        private readonly ILogger<MatiereController> _logger;
        private readonly IAnneeScoService _anneeScoService;
        public AnneeScoController(ILogger<MatiereController> logger, IAnneeScoService anneeScoService)
        {
            _logger = logger;
            _anneeScoService = anneeScoService;
        }

        [HttpGet("RecupererListeAnneesSco")]
        public async Task<IActionResult> RecupererListeAnneesScoAsync()
        {
            var result = await _anneeScoService.ListeAnneesScolaires();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            _logger.LogError("Erreur lors de la récupération de la liste des années scolaires : {Errors}", result.Errors);
            return BadRequest(result.Errors?.FirstOrDefault()?.Message); // Fix: Adjusted to use 'Errors' property
        }
    }
}
