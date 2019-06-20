using EasySetupASPNetCoreAPI.Controllers.V1.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasySetupASPNetCoreAPI.Service
{
    public interface IAccountService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, string firstName, string lastName, string phone);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
