using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using MediatR;
using System.Collections.Generic;

namespace BuildingMaterials.UseCases.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
