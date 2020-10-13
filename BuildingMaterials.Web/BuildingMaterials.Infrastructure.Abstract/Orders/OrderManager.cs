using BuildingMaterials.Infrastructure.Common.Results;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingMaterials.Infrastructure.Abstract.Orders
{
    public interface IOrderManager
    {
        Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);

        Task<ApplicationResult> CreateOrderAsync(CancellationToken cancellationToken = default);
    }
}
