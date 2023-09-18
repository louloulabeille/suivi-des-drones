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
    public class IndexModel : PageModel
    {
        #region propriété
        public List<Drone>? Drones { get; set; } = new();
        public List<HealthStatus> ListeHealthStatus { get; set; } = new();
        public List<string> FiltreMatricule { get; set; } = new();
        private readonly ILogger<IndexModel> _logger;
        //private readonly DroneDbContext _dbContext;
        //private readonly IDroneDataLayer _droneDataLayer;
        private readonly IRepositoryDrone _repository;
        private readonly IRepositoryHealthStatus _healthStatusRepository;
        //private readonly Login? login = null;

        #endregion

        #region contructeur
        public IndexModel(ILogger<IndexModel> logger, IRepositoryDrone droneRepository, IRepositoryHealthStatus healthStatusRepository)
        //public IndexModel(ILogger<IndexModel> logger, Repository<Drone> droneRepository, Repository<HealthStatus> healthStatusRepository)
        {
            _logger = logger;
            //_droneDataLayer = droneDataLayer;
            //_dbContext = context;
            _repository = droneRepository;
            _healthStatusRepository = healthStatusRepository;
            //this.login = login;
        }
        #endregion

        #region méthode
        public IActionResult OnGet()
        {
            //if (login is null) this.RedirectToAction("Login");

            try
            {
                IActionResult result = this.Page();
                
                SetListDrone();
                SetListFiltreDrone();
                SetListFiltreStatus();
                /*if (true)
                {
                    return this.BadRequest();
                }*/

                return result;
            }
            catch
            {
                return this.BadRequest();
            }
            
        }
        #endregion

        #region methode interne
        private void SetListDrone()
        {
            Drones = _repository.GetAll().OrderByDescending(s=>s.CreationDate).OrderBy(l=>l.Matricule).ToList();
            /*Drones.AddRange(new List<Drone>()
            {
                new(){ CreationDate = DateTime.Now, Matricule = "1214MX" , Status = HealthStatus.OK},
                new(){ CreationDate = DateTime.Now.AddMonths(-9) ,Matricule = "1214AT" , Status = HealthStatus.Repair},
                new(){ CreationDate = DateTime.Now.AddMonths(-12) ,Matricule = "2514TG", Status = HealthStatus.Broken},
            });*/
        }
        private void SetListFiltreDrone()
        {
            if (Drones == null) return;
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
            ListeHealthStatus = _healthStatusRepository.GetAll().ToList() ?? new();
        }
        #endregion
    }
}