using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Interfaces.Insfrastructure
{
    public interface ILoginDataLayer
    {
        public bool IsValidLoggin(ref Login login);
    }
}
