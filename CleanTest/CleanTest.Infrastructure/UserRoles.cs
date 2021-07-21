using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTest.Infrastructure
{
    public static class UserRoles
    {
        public const string Admin = "Admin";

        public static List<string> GetRoles()
        {
            return new List<string>() { UserRoles.Admin };
        }
    }
}
