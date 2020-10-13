using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BuildingMaterials.Infrastructure.Domain.Users.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public const string AdminRole = "admin";

        public const string ClientRole = "client";

        public const string ManagerRole = "manager";

        /// <summary>
        /// All application roles.
        /// </summary>
        public static IEnumerable<string> AllRoles => new List<string>
        {
            AdminRole,
            ClientRole,
            ManagerRole
        };
    }
}
