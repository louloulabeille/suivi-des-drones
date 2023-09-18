using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Insfrastructure
{
    public interface IHealthStatusDataLayer
    {
        public ICollection<HealthStatus> GetAll();
        public ICollection<HealthStatus> GetAllNoTracking();
        public void Add(HealthStatus item);
        public void Remove(HealthStatus item);
        public HealthStatus? GetById(int id);
        public int Save();
    }
}
