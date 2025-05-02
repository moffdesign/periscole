using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periscole.Api.Contrats;
using Periscole.Api.Services;

namespace Periscole.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : ControllerBase
    {
        private readonly ILogger<MatiereController> _logger;
        private readonly IProfesseurService _professeurService;
        public ProfesseurController(ILogger<MatiereController> logger, IProfesseurService professeurService)
        {
            _logger = logger;
            _professeurService = professeurService;
        }

    }
}
