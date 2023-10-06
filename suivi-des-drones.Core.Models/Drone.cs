using System.ComponentModel.DataAnnotations;

namespace suivi_des_drones.Core.Models
{
    

    public class Drone //: EntityBase
    {
        #region propriétés
        //public int Id { get; set; }
       //[Required]
        public string Matricule { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        
        public int StatusId { get; set; }
        public HealthStatus Status { get; set; } = HealthStatus.OK;

        public List<Incident> Problemes { get; set; } = new();

        #endregion
    }
}