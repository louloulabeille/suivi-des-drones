using Microsoft.EntityFrameworkCore;
using suivie_des_drones.Cores.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{

    public abstract class BaseSqlServerDataLayer
    {
        private  readonly DroneDbContext _context;

        public BaseSqlServerDataLayer(DroneDbContext dbContext)
        {
            _context = dbContext;
        }

        public DroneDbContext Context { get { return _context; } }
    }
}
