using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class OneDroneModel : PageModel
    {
        #region propriété
        private readonly ILogger<OneDroneModel> _logger;
        private readonly IRepositoryDrone _repository;
        private readonly IRepositoryHealthStatus _healthStatus;

        public List<HealthStatus> ListHeal {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string Matricule {  get; set; } = string.Empty;

        [BindProperty]
        public Drone Drone { get; set; } = default!;
        #endregion

        #region constructeur
        public OneDroneModel(ILogger<OneDroneModel> logger, IRepositoryDrone repository, IRepositoryHealthStatus healthStatus)
        {
            _logger = logger;
            _repository = repository;
            _healthStatus = healthStatus;
            ListHeal = _healthStatus.GetAll().ToList();
        }
        #endregion

        public IActionResult OnGet()
        {
            IActionResult result = Page();
            try
            {
                Drone = _repository.GetById(Matricule) ?? new Drone();
            } catch(Exception ex)
            {
                result = this.NotFound();
            }

            return result;
        }

        public IActionResult OnPost() { 

            IActionResult result = Page();
            if (this.ModelState.IsValid && Drone is not null )
            {
                Drone.Status = Drone.StatusId switch
                {
                    1 => HealthStatus.OK,
                    -1=> HealthStatus.Broken,
                    _ => HealthStatus.Repair,
                };
                try
                {
                    _repository.Update(this.Drone);
                    this.ModelState.Clear();
                    result = this.RedirectToPage("/index");
                }
                catch (Exception ex)
                {
                    result = this.BadRequest();
                }
               
            }
            return result;
        }
    }
}
