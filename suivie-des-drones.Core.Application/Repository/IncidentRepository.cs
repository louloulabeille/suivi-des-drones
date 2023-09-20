using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Repository
{
    public class IncidentRepository : IRepositoryIncident
    {
        private readonly IIncidentDataLayer _dataLayer;

        public IncidentRepository(IIncidentDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ICollection<Incident> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public ICollection<Incident> Take(int nb)
        {
            return _dataLayer.Take(nb);
        }

        public ICollection<Incident> Take(Range range)
        {
            return _dataLayer.Take(range);
        }
    }
}
