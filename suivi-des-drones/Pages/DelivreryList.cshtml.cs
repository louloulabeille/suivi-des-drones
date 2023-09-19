using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class DelivreryListModel : PageModel
    {
        public List<Delivrery> Delivreries { get; set; } = new();
        private readonly ILogger<DelivreryListModel> _logger;
        private readonly IRepositoryDelivrery _repository;

        #region Constructeur
        public DelivreryListModel(ILogger<DelivreryListModel> logger, IRepositoryDelivrery repository)
        {
            _logger = logger;
            _repository = repository;
        }
        #endregion

        public IActionResult OnGet()
        {
            Delivreries = _repository.GetAll().ToList();

            return this.Page();
        }
    }
}
