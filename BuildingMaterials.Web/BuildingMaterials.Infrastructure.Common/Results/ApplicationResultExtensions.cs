using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuildingMaterials.Infrastructure.Common.Results
{
    public static class ApplicationResultExtensions
    {
        public static ApplicationResult GetResultFromIdentityErrors(this IEnumerable<IdentityError> identityErrors)
        {
            var reason = identityErrors.FirstOrDefault()?.Description ?? "Unsucceeded operation";
            return ApplicationResult.Fail(reason, ConvertIdentityErrors(identityErrors).ToArray());
        }

        public static ApplicationResult GetCommandResult(this IdentityResult identityResult)
        {
            if (identityResult.Succeeded)
            {
                return ApplicationResult.Success;
            }
            else
            {
                return identityResult.Errors.GetResultFromIdentityErrors();
            }
        }

        public static ApplicationResult GetCommandResult(this SignInResult signInResult)
        {
            if (signInResult.Succeeded)
            {
                return ApplicationResult.Success;
            }
            else
            {
                return ApplicationResult.Fail("Login failed for the user");
            }
        }

        public static ApplicationResult GetCommandResult(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return ApplicationResult.Success;
            }
            else
            {
                return ApplicationResult.Fail("Validation failed!", ConvertModelStateErrors(modelState).ToArray());
            }
        }

        private static IEnumerable<string> ConvertIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            return identityErrors.Select(error => $"[{error.Code}] {error.Description}");
        }

        private static IEnumerable<string> ConvertModelStateErrors(ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
        }
    }
}
