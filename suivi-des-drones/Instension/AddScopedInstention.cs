using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivie_des_drones.Core.Application.Repository;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Cores.Interfaces.Repository;

namespace suivi_des_drones.Instension
{
    public static class AddScopedInstention
    {
        public static void AddScopedLayerRepository( this IServiceCollection services )
        {
            //Drones
            services.AddScoped<IDroneDataLayer, SqlServerDroneDataLayer>();
            services.AddScoped<IRepositoryDrone, DroneRepository>();
            // HealthStatus
            services.AddScoped<IHealthStatusDataLayer, SqlServerHealthstatusDataLayer>();
            services.AddScoped<IRepositoryHealthStatus, HealthstatusRepository>();
            // Login
            services.AddScoped<ILoginDataLayer, SqlServerLoginDataLayer>();
            services.AddScoped<IRepositoryLogin, LoginRepository>();
            // Delivrery
            services.AddScoped<IDelivreryDataLayer, SqlServerDelivreryDataLayer>();
            services.AddScoped<IRepositoryDelivrery, DelivreryRepository>();
            // Incident
            services.AddScoped<IIncidentDataLayer, SqlServerIncidentDataLayer>();
            services.AddScoped<IRepositoryIncident, IncidentRepository>();
        }
    }
}
