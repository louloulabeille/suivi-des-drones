using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        /// <summary>
        /// utilisation d'un controleur pour faire l'API - on pourra le mettre en place ave un token 
        /// par la suite
        /// </summary>

        private readonly ILogger<IncidentController> _logger;
        private readonly IRepositoryIncident _repository;
        private List<Incident> _incidents = new ();

        public IncidentController(ILogger<IncidentController> logger, IRepositoryIncident repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("index")]
        public JsonResult Incident()
        {
            _incidents.Clear ();
            _incidents.AddRange(_repository.Take(5));
            return new JsonResult(_incidents);
        }
    }
}
