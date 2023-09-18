using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Infrastructure.Database;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Repository
{
    public class HealthstatusRepository : IRepositoryHealthStatus
    {
        private readonly IHealthStatusDataLayer _dataLayer;

        public HealthstatusRepository(IHealthStatusDataLayer dataLayer )
        {
            _dataLayer = dataLayer;
        }

        public void Add(HealthStatus item)
        {
            _dataLayer.Add( item ); 
        }

        public ICollection<HealthStatus> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public ICollection<HealthStatus> GetAllNoTracking()
        {
            return _dataLayer.GetAllNoTracking();
        }

        public HealthStatus? GetById(int id)
        {
            return _dataLayer.GetById( id );
        }

        public void Remove(HealthStatus item)
        {
            _dataLayer.Remove( item );
        }

        public int Save()
        {
            return _dataLayer.Save();
        }
    }
}
