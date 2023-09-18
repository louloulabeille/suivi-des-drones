using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Repository
{
    public interface IRepositoryLogin
    {
        public bool IsValidLoggin(ref Login login);
    }
}
