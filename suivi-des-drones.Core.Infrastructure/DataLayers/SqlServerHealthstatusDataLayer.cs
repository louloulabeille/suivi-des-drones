using Microsoft.EntityFrameworkCore;
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
    public class SqlServerHealthstatusDataLayer : BaseSqlServerDataLayer , IHealthStatusDataLayer
    {
        //protected readonly DroneDbContext _dbContext;
        public SqlServerHealthstatusDataLayer(DroneDbContext context) : base(context) { }

        public void Add(HealthStatus item)
        {
            Context.HealthStatus.Add(item);
        }

        public ICollection<HealthStatus> GetAll()
        {
            // l'autre facon de faire - je n'ai pas besoin de le faire - je fais automatiquement dans le DbContext avec la configuration
            var retour = from item in Context.HealthStatus.Include(i => i.Drones) // include ajoute l'object Healstatus dans Drone
                         select item;

            return Context.HealthStatus.Include(o=>o.Drones).ToList();
            //return retour.ToList();
        }

        public ICollection<HealthStatus> GetAllNoTracking()
        {
            return Context.HealthStatus.AsNoTracking().Include(p=>p.Drones).ToList();
        }

        public HealthStatus? GetById(int id)
        {
            var retour = from item in Context.HealthStatus.Include(i => i.Drones) // include ajoute l'object Healstatus dans Drone
                         where item.Id == id
                         select item;
            return retour.ToList().FirstOrDefault();
        }

        public void Remove(HealthStatus item)
        {
            Context.HealthStatus.Remove(item);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
