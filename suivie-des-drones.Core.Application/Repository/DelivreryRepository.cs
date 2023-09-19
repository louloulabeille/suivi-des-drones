using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Repository
{
    public class DelivreryRepository : IRepositoryDelivrery
    {
        private readonly IDelivreryDataLayer _dataLayer;

        public DelivreryRepository(IDelivreryDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public ICollection<Delivrery> Find(Expression<Func<Delivrery, bool>> predicate)
        {
            return _dataLayer.Find(predicate);
        }

        public ICollection<Delivrery> GetAll()
        {
            return _dataLayer.GetAll();
        }
    }
}
