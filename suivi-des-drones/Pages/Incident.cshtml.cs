using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class IncidentModel : PageModel
    {
        #region propri�t�
        private readonly ILogger<IncidentModel> _logger;
        private readonly IRepositoryIncident _incident;

        private List<Incident> incidents = new();
        #endregion

        #region Constructeur
        public IncidentModel(ILogger<IncidentModel> logger, IRepositoryIncident incident )
        {
            _logger = logger;
            _incident = incident;
        }
        #endregion

        public JsonResult OnGet()
        {
            incidents.Clear();
            incidents.AddRange(_incident.Take(5));
            return new JsonResult(incidents);
        }
    }
}
