using System;
using System.Collections.Generic;
using System.Text;

namespace EasySetupASPNetCoreAPI.Controllers.V1.Response
{
    public class AuthenticationResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
