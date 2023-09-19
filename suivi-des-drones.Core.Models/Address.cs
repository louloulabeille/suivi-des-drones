using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public string Rue { get; set; }
        public string? Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        
        public virtual Customer IdCustomerNavigation { get; set; }
    }
}
