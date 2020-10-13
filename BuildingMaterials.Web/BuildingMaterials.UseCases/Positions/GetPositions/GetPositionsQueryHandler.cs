using BuildingMaterials.Infrastructure.DataAccess;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingMaterials.UseCases.Orders.GetPositions
{
    internal class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, IEnumerable<Position>>
    {
        private readonly AppDbContext appDbContext;
        public GetPositionsQueryHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Position>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            return await appDbContext.Positions.ToListAsync(cancellationToken);
        }
    }
}
