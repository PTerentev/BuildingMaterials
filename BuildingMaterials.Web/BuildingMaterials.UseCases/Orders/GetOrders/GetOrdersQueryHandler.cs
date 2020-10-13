using BuildingMaterials.Infrastructure.DataAccess;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingMaterials.UseCases.Orders.GetOrders
{
    class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly AppDbContext appDbContext;
        public GetOrdersQueryHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await appDbContext.Orders.ToListAsync(cancellationToken);
        }
    }
}
