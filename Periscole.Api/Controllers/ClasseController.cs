using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periscole.Api.Interfaces;
using Periscole.Api.Services;

namespace Periscole.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly ILogger<MatiereController> _logger;
        private readonly IClasseService _classeService;
        public ClasseController(ILogger<MatiereController> logger, IClasseService classeService)
        {
            _logger = logger;
            _classeService = classeService;
        }


    }
}
