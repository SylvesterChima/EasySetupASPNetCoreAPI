using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySetupASPNetCoreAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Restricted
        {
            public const string Test = Base + "/Test";
        }

        public static class Account
        {
            public const string Register = Base + "/Account/register";
            public const string Login = Base + "/Account/login";
        }
    }
}
