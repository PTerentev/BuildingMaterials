using System.ComponentModel.DataAnnotations;
using MediatR;
using BuildingMaterials.Infrastructure.Common.Results;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;
using BuildingMaterials.Infrastructure.Common.Validation;

namespace BuildingMaterials.UseCases.Users.CreateUser
{
    public class CreateUserCommand : IRequest<ApplicationResult>
    {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [MaxLength(255)]
        public string PasswordConfirm { get; set; }

        [ApplicationRole]
        [MaxLength(255)]
        public string Role { get; set; } = ApplicationRole.ClientRole;
    }
}
