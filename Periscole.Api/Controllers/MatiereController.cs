﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periscole.Api.Contrats;
using Periscole.Api.Services;

namespace Periscole.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatiereController : ControllerBase
    {
        private readonly ILogger<MatiereController> _logger;
        private readonly IMatiereService _matiereService;
        public MatiereController(ILogger<MatiereController> logger, IMatiereService matiereService)
        {
            _logger = logger;
            _matiereService = matiereService;
        }

        [HttpGet("RecupererListeMatieres")]
        public async Task<IActionResult> RecupererListeMatieresAsync()
        {
            var result = await _matiereService.RecupererListeMatieres();

            if (result.Success) 
            {
                return Ok(result.Data); 
            }

            _logger.LogError("Erreur lors de la récupération de la liste des matières : {Errors}", result.Errors);
            return BadRequest(result.Errors?.FirstOrDefault()?.Message); // Fix: Adjusted to use 'Errors' property
        }

        [HttpGet("RecupererMatieresParClasseEtAnneeSco")]
        public async Task<IActionResult> RecupererMatieresClasseAnneeScoAsync(int anneeScoId, int classeId)
        {
            var result = await _matiereService.RecupererMatieresClasseAnneeSco(anneeScoId, classeId);

            if (result.Success) 
            {
                return Ok(result.Data); 
            }

            _logger.LogError("Erreur lors de la récupération des matières par classe et année scolaire : {Errors}", result.Errors);
            return BadRequest(result.Errors?.FirstOrDefault()?.Message); 
        }
    }
}
