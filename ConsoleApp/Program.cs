// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Models;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Infrastructure.Database;

Console.WriteLine("Hello, World!");

DroneDbContext droneDbContext = new ();
string script = droneDbContext.Database.GenerateCreateScript();
Console.WriteLine(script);

//DroneRepository dr = new (new (droneDbContext));

/*dr.Add(new Drone()
{
    Matricule = "1452OO",
    CreationDate = DateTime.Now,
    //Status = HealthStatus.OK,
});*/

/*dr.Save();*/
//HealthstatusRepository df = new (new (droneDbContext) );
//df.SetHealthStatus();
//dr.SetDataDroneRepositoryInit();

Console.ReadLine();


