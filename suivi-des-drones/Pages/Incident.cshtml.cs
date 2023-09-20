using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class IncidentModel : PageModel
    {
        #region propriété
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
            return new JsonResult(new List<int>() { 1,2,5,9,7});
        }
    }
}
