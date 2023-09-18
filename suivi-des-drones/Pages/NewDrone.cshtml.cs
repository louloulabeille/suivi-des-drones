using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Interfaces;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    [Authorize]
    public class NewDroneModel : PageModel
    {
        private readonly ILogger<NewDroneModel> _logger;
        private readonly IRepositoryDrone _droneRepository;
        private readonly IRepositoryHealthStatus _healthStatusRepository;

        public readonly List<HealthStatus> ListHeal;
        [BindProperty]
        public Drone Drone { get; set; } = new Drone() { Matricule = string.Empty, CreationDate = DateTime.Now };

        public NewDroneModel(ILogger<NewDroneModel> logger, IRepositoryDrone droneRepository, IRepositoryHealthStatus healthStatusRepository)
        {
            _logger = logger;
            _droneRepository = droneRepository;
            _healthStatusRepository = healthStatusRepository;
            ListHeal = _healthStatusRepository.GetAll().ToList<HealthStatus>();
            //Drone = new Drone() { Matricule = string.Empty, CreationDate = DateTime.Now };
            this.ModelState.Clear();
        }
        
        public void OnGet() // reception Get
        {
        }

        public IActionResult OnPost() // reception post
        {
            PageResult result = this.Page();
            try
            {
                /*if (Drone is not null)
                    Drone.Status = Drone.StatusId switch
                    {
                        1  => _healthStatusRepository.GetById(1)??HealthStatus.OK,
                        -1 => _healthStatusRepository.GetById(-1)??HealthStatus.OK,
                        _  => _healthStatusRepository.GetById(2)??HealthStatus.OK,
                    };
                */

                if (ModelState.IsValid)
                {
                    _droneRepository.Add(Drone);
                    _droneRepository.Save();
                    Drone = new Drone() { Matricule = string.Empty, CreationDate = DateTime.Now };
                    this.ModelState.Clear();
                }
            }
            catch
            {
                return this.BadRequest();
            }
            return result;
        }
    }
}
