using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Repository
{
    public class DroneRepository : IRepositoryDrone
    {
        private readonly IDroneDataLayer _dataLayer;
        public DroneRepository(IDroneDataLayer dataLayer){
            _dataLayer = dataLayer;
        }

        public void Add(Drone item)
        {
            _dataLayer.Add(item);
        }

        public void AddRange(ICollection<Drone> items)
        {
            _dataLayer.AddRange(items);
        }

        public ICollection<Drone> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public ICollection<Drone> GetAllNoTracking()
        {
            return _dataLayer.GetAllNoTracking();
        }

        public Drone? GetById(string id)
        {
            return _dataLayer.GetById(id);
        }

        public void Remove(Drone item)
        {
            _dataLayer.Remove(item);
        }

        public void RemoveRange(ICollection<Drone> items)
        {
            _dataLayer.RemoveRange(items);
        }

        public int Save()
        {
            return _dataLayer.Save();
        }
    }
}
