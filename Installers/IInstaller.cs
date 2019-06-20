using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySetupASPNetCoreAPI.Installers
{
    public interface IInstaller
    {
        void IntallServices(IServiceCollection services, IConfiguration Configuration);
    }
}
