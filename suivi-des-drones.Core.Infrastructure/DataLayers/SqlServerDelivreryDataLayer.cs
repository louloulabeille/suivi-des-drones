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
    public class SqlServerDelivreryDataLayer : BaseSqlServerDataLayer, IDelivreryDataLayer
    {
        public SqlServerDelivreryDataLayer(DroneDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Delivrery> Find(Expression<Func<Delivrery, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Delivrery> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
