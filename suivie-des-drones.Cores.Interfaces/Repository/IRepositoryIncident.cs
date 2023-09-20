using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Repository
{
    public interface IRepositoryIncident
    {
        public ICollection<Incident> GetAll();
        public ICollection<Incident> Take(int nb);
        public ICollection<Incident> Take(Range range);
    }
}
