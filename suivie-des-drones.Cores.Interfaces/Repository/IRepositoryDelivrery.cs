using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Repository
{
    public interface IRepositoryDelivrery
    {
        public ICollection<Delivrery> GetAll();
        public ICollection<Delivrery> Find(Expression<Func<Delivrery, bool>> predicate);
    }
}
