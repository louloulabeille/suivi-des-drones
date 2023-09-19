using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Tests.Web_UI.Fakes
{
    public class FakeDelivreryRepository : IRepositoryDelivrery
    {
        public ICollection<Delivrery> Find(Expression<Func<Delivrery, bool>> predicate)
        {
            return new List<Delivrery>()
            {
                new Delivrery(),
                new Delivrery(),
            };
        }

        public ICollection<Delivrery> GetAll()
        {
            return new List<Delivrery>()
            {
                new Delivrery(),
                new Delivrery(),
            };
        }
    }
}
