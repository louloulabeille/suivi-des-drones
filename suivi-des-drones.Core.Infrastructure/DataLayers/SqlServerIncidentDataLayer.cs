using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Infrastructure.Database;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    public class SqlServerIncidentDataLayer : BaseSqlServerDataLayer, IIncidentDataLayer
    {
        public SqlServerIncidentDataLayer(DroneDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Incident> GetAll()
        {
            return Context.Incidents.ToList();
        }

        public ICollection<Incident> Take(int nb)
        {
            return Context.Incidents.Take(nb).ToList();
        }

        public ICollection<Incident> Take(Range range)
        {
            return Context.Incidents.Take(range).ToList();
        }
    }
}
