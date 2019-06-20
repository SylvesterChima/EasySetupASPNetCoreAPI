using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySetupASPNetCoreAPI.Controllers.V1.Response
{
    public class RegisterResponse
    {
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
