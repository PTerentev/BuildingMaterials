using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;

namespace BuildingMaterials.Infrastructure.Common.Validation
{
    public class ApplicationRoleAttribute : ValidationAttribute
    {
        public ApplicationRoleAttribute()
        {
            ErrorMessage = "The application does not contain such a user role!";
        }

        public override bool IsValid(object value)
        {
            if (value is string role)
            {
                return ApplicationRole.AllRoles.Contains(role);
            }

            return false;
        }
    }
}
