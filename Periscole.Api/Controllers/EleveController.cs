using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periscole.Api.Contrats;

namespace Periscole.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleveController : ControllerBase
    {
        private readonly ILogger<EleveController> _logger;
        private readonly IEleveService _eleveService;

        public EleveController( ILogger<EleveController> logger, IEleveService eleveService ) 
        {
            _logger = logger;
            _eleveService = eleveService;
        }

        [HttpGet("RecupererListeEleves")]
        public async Task<IActionResult> RecupererListeElevesAsync()
        {
            var result = await _eleveService.RecupererListeElevesAsync();
            if (result.Success) 
            {
                return Ok(result.Data); 
            }

            _logger.LogError("Erreur lors de la récupération de la liste des élèves : {Errors}", result.Errors);
            return BadRequest(result.Errors?.FirstOrDefault()?.Message); // Fix: Adjusted to use 'Errors' property
        }

    }
}
