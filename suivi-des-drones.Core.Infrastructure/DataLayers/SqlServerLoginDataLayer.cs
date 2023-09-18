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
    public class SqlServerLoginDataLayer : BaseSqlServerDataLayer, ILoginDataLayer
    {
        //protected readonly DroneDbContext _dbContext;

        public SqlServerLoginDataLayer(DroneDbContext context) : base (context) { }
        

        public bool IsValidLoggin(Login login)
        {
            var logins = from item in Context.Login
                         where item.Password.Equals(login.Password) &&
                         item.Email == login.Email
                         select item;

            return logins.Any();
        }
    }
}
