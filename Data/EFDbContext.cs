using System;
using System.Collections.Generic;
using System.Text;
using EasySetupASPNetCoreAPI.Controllers.V1.Request;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasySetupASPNetCoreAPI.Data
{
    public class EFDbContext : IdentityDbContext<ApplicationUser>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
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
}
