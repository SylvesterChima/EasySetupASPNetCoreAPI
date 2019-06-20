using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySetupASPNetCoreAPI.Controllers.V1.Request;
using EasySetupASPNetCoreAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasySetupASPNetCoreAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void IntallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EFDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<EFDbContext>();
        }
    }
}
