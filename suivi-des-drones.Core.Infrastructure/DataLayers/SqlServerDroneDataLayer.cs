﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class SqlServerDroneDataLayer : BaseSqlServerDataLayer , IDroneDataLayer
    {
        //protected readonly DroneDbContext _dbContext;

        public SqlServerDroneDataLayer(DroneDbContext context) : base (context) {
        }

        public void Add(Drone item)
        {
         // détaché attention au item status car en faisant le detached sur l'object item.status il me désactive tout l'object
            Context.Entry<HealthStatus>(item.Status).State = EntityState.Detached;    // détaché l'object pour ne pas qu'il soit en enregistrement dasn add*/
            Context.Entry<Drone>(item).State = EntityState.Added;
            Context.Add(item);
        }

        public void AddRange(ICollection<Drone> items)
        {
            Context.AddRange(items);
        }

        public ICollection<Drone> Find(Expression<Func<Drone, bool>> predicate)
        {
            return Context.Drones.Where(predicate).ToList();
        }

        public ICollection<Drone> GetAll()
        {
            // l'autre facon de faire - je n'ai pas besoin de le faire - je fais automatiquement dans le DbContext avec la configuration
            var retour = from item in Context.Drones.Include(i => i.Status) // include ajoute l'object Healstatus dans Drone
                         select item;

            return Context.Drones.ToList();
        }

        public ICollection<Drone> GetAllNoTracking()
        {
            return Context.Drones.Include(i=>i.Status).AsNoTracking<Drone>().ToList();
        }

        public Drone? GetById(string id)
        {
            return Context.Drones.Find(id);
        }

        public void Remove(Drone item)
        {
            Context.Remove(item);
        }

        public void RemoveRange(ICollection<Drone> items)
        {
            Context.RemoveRange(items);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Update(Drone item)
        {
            Drone? drone = Context.Drones.Find(item.Matricule); // retourne le drone attaché au Context
            if (string.IsNullOrEmpty(item.Matricule) || drone is null)
                return;
            
            // comme j'affiche la liste avant et après je fais une modification vers une autre fenêtre
            // le context garde le drone qui a été trouvé dans la liste et il est bloqué
            // voici pour débloqué celui qui est géré dans le context et après passé item en modified
            Context.Entry<Drone>(drone).State = EntityState.Detached;
            Context.Entry<Drone>(item).State = EntityState.Modified; // après si c'est le même pas grave
            //////////////////////// -- je ne sais pas s'il faut le faire comme ceci

            if (Context.Entry<Drone>(item).State == EntityState.Modified)
                Context.SaveChanges();
        }

    }
}
