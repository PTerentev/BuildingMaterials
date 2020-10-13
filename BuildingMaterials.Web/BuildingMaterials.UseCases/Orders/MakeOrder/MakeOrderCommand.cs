using MediatR;
using System.Collections.Generic;

namespace BuildingMaterials.UseCases.Orders.MakeOrder
{
    public class MakeOrderCommand : IRequest
    {
        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public IDictionary<int, int> Carts { get; set; } = new Dictionary<int, int>();

        public string Information { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
