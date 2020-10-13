using BuildingMaterials.Infrastructure.DataAccess;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingMaterials.UseCases.Orders.MakeOrder
{
    internal class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand>
    {
        private readonly AppDbContext appDbContext;
        public MakeOrderCommandHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Adress = request.Address,
                CustomerName = request.FirstName + " " + request.LastName,
                Information = request.Information,
                MobileNumber = request.MobileNumber
            };

            appDbContext.Orders.Add(order);

            appDbContext.Carts.AddRange(request.Carts
                .Select(c => new Cart()
                {
                    Count = c.Value,
                    PositionId = c.Key,
                    OrderId = order.Id
                }));

            await appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
