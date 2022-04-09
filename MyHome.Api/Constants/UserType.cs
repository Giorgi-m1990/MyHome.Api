using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Api.Constants
{
    public static class UserType
    {
        public const string Admin = "Admin";
        public const string Supervisor = "Supervisor";
        public const string User = "User";
        public const string AdminUser = "Admin, User";
        public const string SupervisorAdmin = "Supervisor, Admin";
    }
}
