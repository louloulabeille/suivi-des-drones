using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Infrastructure.DataLayers;
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
    /*public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SqlServerDataLayer<T> _dataLayer;

        public Repository(SqlServerDataLayer<T> dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public void Add(T item)
        {
            _dataLayer.Add(item);
        }

        public void AddRange(ICollection<T> items)
        {
            _dataLayer.AddRange(items);
        }

        public virtual ICollection<T> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public ICollection<T> GetAllNoTracking()
        {
            return _dataLayer.GetAllNoTracking();
        }

        public virtual T? GetById(int id)   // à repprogrammer
        {
            //if (typeof(T).FullName == "Drone") { throw new Exception(); }
            return _dataLayer.GetById(id);
        }

        public T? GetById(string id)
        {
            if (typeof(T).FullName == "Drone") {
                return _dataLayer.GetById(id);
            }
            throw new Exception();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return _dataLayer.Save();
        }

        public void DetecteChange()
        {
            _dataLayer.DetectChange();
        }
    }*/
}
