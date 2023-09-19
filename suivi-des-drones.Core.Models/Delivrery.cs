using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    /// <summary>
    /// classe modele de livraison de drones
    /// </summary>
    public class Delivrery
    {
        public int Id { get; set; }
        public int IdCustomer {  get; set; }
        public DateTime DateLivraison { get; set; }
        public bool Livraison { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }

        public virtual ICollection<Drone> DronesDelivrery { get; set; } = new List<Drone>();
    }
}
