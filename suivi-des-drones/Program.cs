using suivie_des_drones.Cores.Infrastructure.Database;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Core.Application.Repository;
using suivi_des_drones.Core.Models;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivie_des_drones.Cores.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options=> {
    options.Conventions.AddPageRoute("/NewDrone", "/creation-drone");   // redirection url
});

builder.Services.AddDbContext<DroneDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Context:Sql"]);
});
builder.Services.AddScoped<IDroneDataLayer, SqlServerDroneDataLayer>();
builder.Services.AddScoped<IRepositoryDrone, DroneRepository>();

builder.Services.AddScoped<IHealthStatusDataLayer, SqlServerHealthstatusDataLayer>();
builder.Services.AddScoped<IRepositoryHealthStatus, HealthstatusRepository>();

builder.Services.AddScoped<ILoginDataLayer, SqlServerLoginDataLayer>();
builder.Services.AddScoped<IRepositoryLogin, LoginRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
