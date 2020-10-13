using System.Threading;
using System.Threading.Tasks;
using BuildingMaterials.Infrastructure.Common.Results;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuildingMaterials.UseCases.Authentication.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApplicationResult>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <inheritdoc/>
        public async Task<ApplicationResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return ApplicationResult.Fail("The user with such email does not exist!");
            }

            var result = await signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            return result.GetCommandResult();
        }
    }
}
