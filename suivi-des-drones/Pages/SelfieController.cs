using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using suivi_des_drones.Core.Infrastructure.Database;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Cores.Infrastructure.Database;

namespace suivi_des_drones.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private readonly SelfieDbContext _context;

        public SelfieController(SelfieDbContext context)
        {
            _context = context;
        }

        public ICollection<Selfie> Selfies()
        {
            return _context.Selfies.ToList();
        }
    }
}
