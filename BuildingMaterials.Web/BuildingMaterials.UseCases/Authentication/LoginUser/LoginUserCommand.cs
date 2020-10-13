using System.ComponentModel.DataAnnotations;
using BuildingMaterials.Infrastructure.Common.Results;
using MediatR;

namespace BuildingMaterials.UseCases.Authentication.LoginUser
{
    /// <summary>
    /// Login user command.
    /// </summary>
    public class LoginUserCommand : IRequest<ApplicationResult>
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Remember user's cookie for longer period.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
