using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Interfaces;
using suivie_des_drones.Cores.Infrastructure.Database;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using System.Text;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Pages
{
    public class IndexOldModel : PageModel
    {
        #region propriété
        public List<Drone> Drones { get; set; } = new();
        public List<HealthStatus> ListeHealthStatus { get; set; } = new();
        public List<string> FiltreMatricule { get; set; } = new();
        private readonly ILogger<IndexModel> _logger;
        //private readonly DroneDbContext _dbContext;
        //private readonly IDroneDataLayer _droneDataLayer;
        private readonly IRepositoryDrone _repository;
        private readonly IRepositoryHealthStatus _healthStatusRepository;

        #endregion

        #region contructeur
        //public IndexModel(ILogger<IndexModel> logger, IRepository<Drone> droneRepository, IRepository<HealthStatus> healthStatusRepository)
        public IndexOldModel(ILogger<IndexModel> logger, IRepositoryDrone droneRepository, IRepositoryHealthStatus healthStatusRepository)
        {
            _logger = logger;
            //_droneDataLayer = droneDataLayer;
            //_dbContext = context;
            _repository = droneRepository;
            _healthStatusRepository = healthStatusRepository;
        }
        #endregion

        #region méthode
        public IActionResult OnGet()
        {
            //redirection 
            //IActionResult result = this.Page();
            IActionResult result = this.RedirectPermanent("/Index");

            SetListDrone();
            SetListFiltreDrone();
            SetListFiltreStatus();
            /*if (true)
            {
                return this.BadRequest();
            }*/

            return result;
        }
        #endregion

        #region methode interne
        private void SetListDrone()
        {
            Drones = _repository.GetAll().ToList();
            /*Drones.AddRange(new List<Drone>()
            {
                new(){ CreationDate = DateTime.Now, Matricule = "1214MX" , Status = HealthStatus.OK},
                new(){ CreationDate = DateTime.Now.AddMonths(-9) ,Matricule = "1214AT" , Status = HealthStatus.Repair},
                new(){ CreationDate = DateTime.Now.AddMonths(-12) ,Matricule = "2514TG", Status = HealthStatus.Broken},
            });*/
        }
        private void SetListFiltreDrone()
        {
            FiltreMatricule.AddRange(Drones.GroupBy(x => x.Matricule[..4]).Select(x => x.Key));
        }

        private void SetListFiltreStatus()
        {
            /*ListeHealthStatus.AddRange(new List<HealthStatus>()
            {
                HealthStatus.OK,
                HealthStatus.Broken,
                HealthStatus.Repair,
            });*/
            ListeHealthStatus.AddRange(_healthStatusRepository.GetAll());
        }
        #endregion
    }
}