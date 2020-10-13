using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using MediatR;
using System.Collections.Generic;

namespace BuildingMaterials.UseCases.Orders.GetPositions
{
    public class GetPositionsQuery : IRequest<IEnumerable<Position>>
    {
    }
}
