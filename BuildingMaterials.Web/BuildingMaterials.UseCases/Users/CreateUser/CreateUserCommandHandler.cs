using System.Threading;
using System.Threading.Tasks;
using BuildingMaterials.Infrastructure.Common.Results;
using BuildingMaterials.Infrastructure.DataAccess;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuildingMaterials.UseCases.Users.CreateUser
{
    /// <summary>
    /// Create user command handler.
    /// </summary>
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationResult>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Initialize <see cref="CreateUserCommandHandler"/>.
        /// </summary>
        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        /// <inheritdoc/>
        public async Task<ApplicationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            using var transaction = appDbContext.Database.BeginTransaction();
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = request.Username,
                };

                var identityResult = await userManager.CreateAsync(user, request.Password);

                if (!identityResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return identityResult.GetCommandResult();
                }

                identityResult = await userManager.AddToRoleAsync(user, request.Role);

                if (!identityResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return identityResult.GetCommandResult();
                }

                await transaction.CommitAsync();
                return ApplicationResult.Success;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
