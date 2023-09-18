using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Infrastructure.Database;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    /*public class SqlServerDataLayer<T> : IDroneDataLayer<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DroneDbContext _dbContext;

        public SqlServerDataLayer(DroneDbContext context )
        {
            _dbSet = context.Set<T>();
            _dbContext = context;
        }

        public virtual void Add(T item)
        {
            _dbSet.Add(item);
        }

        public virtual void AddRange(ICollection<T> items)
        {
            _dbSet.AddRange(items);
        }

        public virtual ICollection<T> GetAll()
        {
            // l'autre facon de faire - je n'ai pas besoin de le faire - je fais automatiquement dans le DbContext avec la configuration
            //var retour = from item in _dbContext.Drones.Include(i=>i.Status) // include ajoute l'object Healstatus dans Drone
            //             select item;

            return _dbSet.ToList<T>();
        }

        public virtual ICollection<T> GetAllNoTracking()
        {
            return _dbSet.AsNoTracking().ToList<T>();
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public virtual int Save()
        {
            return _dbContext.SaveChanges();
        }

        public virtual void DetectChange()
        {
            _dbContext.ChangeTracker.DetectChanges();
        }

        public ICollection<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }*/
}
