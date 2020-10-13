using System.Threading;
using System.Threading.Tasks;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuildingMaterials.UseCases.Authentication.LogoutUser
{
    internal class LogoutUserCommandHandler : AsyncRequestHandler<LogoutUserCommand>
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutUserCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        protected override async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();
        }
    }
}
