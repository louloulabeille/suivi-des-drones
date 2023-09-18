﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Areas.Identity.Data;

namespace suivi_des_drones.Data;

public class AuthentificationUserContext : IdentityDbContext<AuthentificationUser>
{
    public AuthentificationUserContext(DbContextOptions<AuthentificationUserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
