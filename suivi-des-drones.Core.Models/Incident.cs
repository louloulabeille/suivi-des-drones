using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public DateTime DateIncident { get; set; }
        public string IdDrone { get; set; } = default!;
        [DataType(DataType.Url)]
        public string? PathFichier { get; set; }
        public string Raison { get; set; } = string.Empty;
        public Drone IdDroneNav { get; set; }

    }
}
