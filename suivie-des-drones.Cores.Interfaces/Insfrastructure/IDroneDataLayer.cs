using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Insfrastructure
{
    public interface IDroneDataLayer
    {
        public ICollection<Drone> GetAll();
        public ICollection<Drone> GetAllNoTracking();
        public void Add(Drone item);
        public void Remove(Drone item);
        public void RemoveRange(ICollection<Drone> items);
        public Drone? GetById(string id);
        public void AddRange(ICollection<Drone> items);
        public void Update(Drone item);
        public int Save ();
        public ICollection<Drone> Find(Expression<Func<Drone,bool>> predicate);
    }
}
