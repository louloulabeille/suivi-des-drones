using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    //public enum HealthStatus
    //{
    //    Ok = 0,
    //    Brokeen = -1,
    //    Repair = -2,
    //}

    /*public class HealthStatus
    {
        public static HealthStatus OK = new HealthStatus() { Id = 0, Label = "OK" };
        public static HealthStatus Broken = new HealthStatus() { Id = 0, Label = "Cassé" };
        public static HealthStatus Repair = new HealthStatus() { Id = 0, Label = "en réparation" };

        public int Id { get; set; } = 0;
        public string Label { get; set; } = default!;
    }*/

    //public record HealthStatus (int Id, string Label);
    public record HealthStatus
    {
        public static HealthStatus OK = new () { Id = 1, Label = "OK" };
        public static HealthStatus Broken = new () { Id = -1, Label = "Cassé" };
        public static HealthStatus Repair = new () { Id = 2, Label = "en réparation" };

        public int Id { get; init; }
        public string Label { get; init; } = default!;

        public virtual ICollection<Drone> Drones { get; set; } = new List<Drone>();
    }

}
