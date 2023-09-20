using suivie_des_drones.Cores.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using suivie_des_drones.Cores.Interfaces.Insfrastructure;
using suivie_des_drones.Core.Application.Repository;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivie_des_drones.Cores.Interfaces.Repository;
using suivi_des_drones.Core.Infrastructure;
using suivi_des_drones.Core.Infrastructure.Web.Constraint;
using Serilog;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthentificationUserContextConnection") 
    ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/NewDrone", "/creation-drone");   // redirection url
});

// logging - Nugets : Serilog & Serilog.Extensions.Logging.File
builder.Logging.AddFile("Logs/suivie-de-drones-{Date}.txt", isJson: true);

#region DbContext
builder.Services.AddDbContext<DroneDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Context:Sql"]);
    
});

builder.Services.AddDbContext<AuthentificationUserContext>(options =>
{
    options.UseSqlServer(connectionString);
    
});
#endregion

builder.Services.AddDefaultIdentity<AuthentificationUser>(options => {
    // toutes les options au niveau de l'authentification qui peuvent mettre en place
        options.SignIn.RequireConfirmedAccount = true;
    }).AddEntityFrameworkStores<AuthentificationUserContext>();

#region injection Model & WorkOfUnit & Repository
// Drone
builder.Services.AddScoped<IDroneDataLayer, SqlServerDroneDataLayer>();
builder.Services.AddScoped<IRepositoryDrone, DroneRepository>();
// HealthStatus
builder.Services.AddScoped<IHealthStatusDataLayer, SqlServerHealthstatusDataLayer>();
builder.Services.AddScoped<IRepositoryHealthStatus, HealthstatusRepository>();
// Login
builder.Services.AddScoped<ILoginDataLayer, SqlServerLoginDataLayer>();
builder.Services.AddScoped<IRepositoryLogin, LoginRepository>();
// Delivrery
builder.Services.AddScoped<IDelivreryDataLayer, SqlServerDelivreryDataLayer>();
builder.Services.AddScoped<IRepositoryDelivrery, DelivreryRepository>();
// Incident
builder.Services.AddScoped<IIncidentDataLayer, SqlServerIncidentDataLayer>();
builder.Services.AddScoped<IRepositoryIncident, IncidentRepository>();
#endregion

// gestion des sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.Configure<RouteOptions>(options => {

    options.ConstraintMap.Add("matricule-contraint",typeof(MatriculeRouteConstraint));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseStatusCodePages("text/html","<h1>Erreur Pas de POOOOO</h1> {0}"); prise en charge de l'erreur en production
//app.UseStatusCodePagesWithReExecute("/Error");  // page par défaut dans le projet la meme que dans la section isDeveloppement
app.UseStatusCodePagesWithRedirects("/Errors/{0}"); 

app.UseRouting();
app.UseAuthentication();    // ajout de l'authentification de identity au niveau des pages 
app.UseSession();           // démarrage de la session
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); // mise en place de la route controller par défault

/*app.Use(async(context, next) => {

    var id = context.Session.GetInt32("UserId");
    var IsLoginPage = context.Request.Path.Value?.ToLower().Contains("login");
    if (!id.HasValue && (!IsLoginPage.HasValue || !IsLoginPage.Value))
    {
        context.Response.Redirect("login");
        return;
    }
    await next.Invoke(context);
});*/
//app.UseRedirectIfNotConnected(); // utilisation d"un middleware

app.MapRazorPages();

app.Run();
