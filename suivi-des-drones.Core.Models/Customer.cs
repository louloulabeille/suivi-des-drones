using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; }

    }
}
