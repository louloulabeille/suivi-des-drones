using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Core.Application.Repository
{
    public class LoginRepository : IRepositoryLogin
    {
        private readonly ILoginDataLayer _dataLayer;
        public LoginRepository(ILoginDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public bool IsValidLoggin(Login login)
        {
            return _dataLayer.IsValidLoggin(login);
        }
    }
}
